using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApi.CreateModel;
using TestCoreApi.Data;
using TestCoreApi.Dtos;
using TestCoreApi.Mapper;
using TestCoreApi.Models;
using TestCoreApi.UpdateModel;

namespace TestCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentsAPIDbContext dbContext;

        public StudentController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetStudentDetail")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await dbContext.Students.ToListAsync();
            return students.Select(s => StudentMapper.MapToDto(s)).ToList();
        }

        [HttpGet]
        [Route("GetStudent{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return StudentMapper.MapToDto(student);
        }

        [HttpPost]
        [Route("PostStudent")]
        public async Task<ActionResult<StudentDto>> PostStudent(StudentCreate studentCreate)
        {
            try
            {
                // Check if the provided StandardId exists
                var standard = await dbContext.Standards.FindAsync(studentCreate.StandardId);
                if (standard == null)
                {
                    return BadRequest("Invalid StandardId. Standard with the provided Id does not exist.");
                }

                // Get the maximum RollNo for the given StandardId
                int maxRollNoForStandard = await dbContext.Students
                    .Where(s => s.StandardId == studentCreate.StandardId)
                    .MaxAsync(s => (int?)s.RollNo) ?? 0;

                Student student = StudentMapper.Map(studentCreate);
                student.RollNo = maxRollNoForStandard + 1; // Generate a new RollNo based on the StandardId

                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutStudent{id}")]
        public async Task<ActionResult> PutStudent(Guid id, StudentUpdate studentUpdate)
        {
            try
            {
                var student = await dbContext.Students.FindAsync(id);

                if (student == null)
                {
                    return NotFound();
                }

                StudentMapper.MapToEntity(studentUpdate, student);
                dbContext.Entry(student).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(studentUpdate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteStudent{id:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student != null)
            {
                dbContext.Remove(student);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            return NotFound();

        }

        [HttpGet]
        [Route("IsLogin")]
        public async Task<IActionResult> IsLogin(string email)
        {
            try
            {
                var student = await dbContext.Students.FirstOrDefaultAsync(u => u.Email == email);
                {
                    if (student != null)
                    {
                        return Ok(new { email = student.Email, password = student.Password});
                    }
                    else
                    {
                        return NotFound("User not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
