using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApi.create;
//using TestCoreApi.CreateModel;
using TestCoreApi.Data;
using TestCoreApi.Dtos;

using TestCoreApi.Maps;


//using TestCoreApi.Mapper;
using TestCoreApi.Models;

namespace TestCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private readonly StudentsAPIDbContext dbContext;
        public StandardController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetStandard")]
        public async Task<ActionResult<Standard>> GetStandard()
        {
            return Ok(await dbContext.Standards.ToListAsync());
        }
        
        [HttpPost]
        [Route("PostStandard")]
        public async Task<ActionResult> PostStandard(Standard1 standard1)
        {
            try
            {


                Standard standard =Standard1Mapper.Maps(standard1);
                standard1.Id = Guid.NewGuid();
               
                await dbContext.Standards.AddAsync(standard);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /*
        [HttpPut]
        [Route("PutAdminTeachers{id}")]
        public async Task<ActionResult> PutAdminTeacher(Guid id, AdminTeacherDto adminTeacherDto)
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
        }*/
    }
}