using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;
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
        [Route("GetTeachers")]
        public async Task<ActionResult<IEnumerable<AdminTeacherDto>>> GetTeachers()
        {
            var adminTeachers = await dbContext.AdminTeachers.Where(x=>x.IsAdmin!=true).ToListAsync();
            return adminTeachers.Select(s => AdminTeacherMapper.MapToDto(s)).ToList();
        }

        [HttpGet]
        [Route("GetAdmins")]
        public async Task<ActionResult<IEnumerable<AdminTeacherDto>>> GetAdmins()
        {
            var adminTeachers = await dbContext.AdminTeachers.Where(x => x.IsAdmin == true).ToListAsync();
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
                if (adminteachercreate.IsAdmin == true)
                {
                    adminteacher.StandardId = null;
                    adminteacher.SubjectId = null;
                }
                else
                {
                    var standard = dbContext.Standards.Where(x => x.StandardNumber == adminteachercreate.StandardNumber && x.Section.ToLower() == adminteachercreate.Section.ToLower()).FirstOrDefault();
                    if (standard == null)
                    {
                        return BadRequest("Invalid StandardId. Standard with the provided Id does not exist.");
                    }
                    adminteacher.StandardId = standard.Id;

                    var subject = dbContext.Subjects.Where(x => x.Name.ToLower() == adminteachercreate.SubjectName.ToLower()).FirstOrDefault();
                    if (subject == null)
                    {
                        return BadRequest("Invalid SubjectId. Standard with the provided Id does not exist.");
                    }
                    adminteacher.SubjectId = subject.Id;
                }
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

                AdminTeacherMapper.MapToEntity(adminTeacherUpdate,adminTeacher);
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
                            return Ok(new { email = admin.Email, id = admin.Id });
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
                            return Ok(new { email = teacher.Email, id = teacher.Id });
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
                            return Ok(new { email = student.Email, id = student.Id });
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
        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(PasswordRequestModel changePassword)
        {
            var existingUser = await dbContext.AdminTeachers.FirstOrDefaultAsync(u => u.Email == changePassword.Email);

            if (existingUser == null)
            {
                return Ok("Email not Found");
            }

            else if (existingUser.BirthDate != changePassword.BirthDate)
            {
                return Ok("Incorrect BirthDate");
            }

            existingUser.Password = changePassword.Password;
            await dbContext.SaveChangesAsync();

            return Ok("Password updated successfully");
        }

    }
}
