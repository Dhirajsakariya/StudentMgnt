using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApi.CreateModel;
using TestCoreApi.Data;
using TestCoreApi.Dtos;
using TestCoreApi.Mapper;
using TestCoreApi.Models;
using TestCoreApi.RequestModel;
using TestCoreApi.UpdateModel;

namespace TestCoreApi.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTeacherController : ControllerBase
    {
        private readonly StudentsAPIDbContext  dbContext;
        public AdminTeacherController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAdminTeachers")]
        public async Task<ActionResult<IEnumerable<AdminTeacherDto>>> GetAdminTeacher()
        {
            var adminTeachers = await dbContext.AdminTeachers.ToListAsync();
            return adminTeachers.Select(s => AdminTeacherMapper.MapToDto(s)).ToList();
        }

        [HttpGet]
        [Route("GetAdminTeacher{id}")]
        public async Task<ActionResult<AdminTeacherDto>> GetAdminTeacher(Guid id)
        {
            var adminTeacher = await dbContext.AdminTeachers.FindAsync(id);

            if (adminTeacher == null)
            {
                return NotFound();
            }

            return AdminTeacherMapper.MapToDto(adminTeacher);
        }

        [HttpPost]
        [Route("PostAdminTeachers")]
        public async Task<ActionResult> PostAdminTeacher(AdminTeacherCreate adminteachercreate)
        {
            try
            {
                var existinguser = await dbContext.AdminTeachers.Where(u => u.Email == adminteachercreate.Email).FirstOrDefaultAsync();
                if (existinguser != null)
                {
                    return Ok("email already exists");
                }
                AdminTeacher adminteacher = AdminTeacherMapper.Map(adminteachercreate);
                adminteacher.Id = Guid.NewGuid();
                await dbContext.AdminTeachers.AddAsync(adminteacher);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutAdminTeachers{id}")]
        public async Task<ActionResult> PutAdminTeacher(Guid id,AdminTeacherUpdate adminTeacherUpdate) 
        {
            try
            {
                var adminTeacher = await dbContext.AdminTeachers.FindAsync(id);

                if (adminTeacher == null)
                {
                    return NotFound();
                }

                AdminTeacherMapper.MapToEntity(adminTeacherUpdate);
                dbContext.Entry(adminTeacher).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(adminTeacherUpdate);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAdminTeacher{id:guid}")]
        public async Task<IActionResult> DeleteAdminTeacher([FromRoute] Guid id)
        {
            var adminTeacher = await dbContext.AdminTeachers.FindAsync(id);

            if (adminTeacher != null)
            {
                dbContext.Remove(adminTeacher);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("IsLogin")]
        public async Task<IActionResult> IsLogin(LoginRequestModel loginRequestModel)
        {
            try
            {
                if(loginRequestModel.Role.ToLower() == "admin")
                {
                    var admin = await dbContext.AdminTeachers.FirstOrDefaultAsync(u => u.Email == loginRequestModel.Email && u.Password == loginRequestModel.Password && u.IsAdmin == true);
                    {
                        if (admin != null)
                        {
                            return Ok(new { email = admin.Email, password = admin.Password });
                        }
                        else
                        {
                            return NotFound("User not found!");
                        }
                    }

                }
                else if(loginRequestModel.Role.ToLower() == "teacher")
                {
                    var teacher = await dbContext.AdminTeachers.FirstOrDefaultAsync(u => u.Email == loginRequestModel.Email && u.Password == loginRequestModel.Password && u.IsAdmin == false);
                    {
                        if (teacher != null)
                        {
                            return Ok(new { email = teacher.Email, password = teacher.Password });
                        }
                        else
                        {
                            return NotFound("User not found!");
                        }
                    }
                }
                else
                {
                    var student = await dbContext.Students.FirstOrDefaultAsync(u => u.Email == loginRequestModel.Email && u.Password == loginRequestModel.Password);
                    {
                        if (student != null)
                        {
                            return Ok(new { email = student.Email, password = student.Password });
                        }
                        else
                        {
                            return NotFound("User not found!");
                        }
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
