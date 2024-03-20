using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApi.CreateModel;
using TestCoreApi.Data;
using TestCoreApi.Dtos;
using TestCoreApi.Mapper;
using TestCoreApi.Models;
  
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
        [Route("GetAdminTeacherDetail")]
        public async Task<ActionResult<AdminTeacher>> GetAdminTeachers()
        {
            return Ok(await dbContext.AdminTeachers.ToListAsync());
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
                //adminteacher.createdat = adminteacher.lastmodifiedat = datetime.now ;
                //adminteacher.createdby = adminteacher.modifiedby =  adminteacher.id;
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
        public async Task<ActionResult> PutAdminTeacher(Guid id,AdminTeacherDto adminTeacherDto)
        {
            try
            {
                var adminTeacher = await dbContext.AdminTeachers.FindAsync(id);

                if (adminTeacher == null)
                {
                    return NotFound();
                }
                adminTeacher.Name = adminTeacherDto.Name;
                adminTeacher.Email = adminTeacherDto.Email;
                adminTeacher.Password = adminTeacherDto.Password;
                adminTeacher.Gender = adminTeacherDto.Gender;
                adminTeacher.BirthDate = adminTeacherDto.BirthDate;
                adminTeacher.MobileNumber = adminTeacherDto.MobileNumber;
                adminTeacher.JoinDate = adminTeacherDto.JoinDate;
                adminTeacher.Address = adminTeacherDto.Address;
                adminTeacher.City = adminTeacherDto.City;
                adminTeacher.District = adminTeacherDto.District;
                adminTeacher.State = adminTeacherDto.State;
                adminTeacher.PinCode = adminTeacherDto.PinCode;
                adminTeacher.IsAdmin = adminTeacherDto.IsAdmin;

                dbContext.Entry(adminTeacher).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(adminTeacher);

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

        [HttpGet]
        [Route("IsLogin")]
        public async Task<IActionResult> IsLogin(string email)
        {
            try
            {
                var adminTeacher = await dbContext.AdminTeachers.FirstOrDefaultAsync(u => u.Email == email);
                {
                    if (adminTeacher != null)
                    {
                        return Ok(new { email = adminTeacher.Email, password = adminTeacher.Password, isAdmin = adminTeacher.IsAdmin });
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
