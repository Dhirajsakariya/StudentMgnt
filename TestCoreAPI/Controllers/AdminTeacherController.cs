using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApi.CreateModel;
using TestCoreApi.Data;
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
        public async Task<ActionResult> PostAdminTeacher(AdminTeacherCreate adminTeacherCreate)
        {
            try
            {
                var existingUser = await dbContext.AdminTeachers.Where(u => u.Email == adminTeacherCreate.Email).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    return Ok("email already exists");
                }
                AdminTeacher adminTeacher = AdminTeacherMapper.Map(adminTeacherCreate);
                adminTeacher.Id = Guid.NewGuid();
                //adminTeacher.CreatedAt = adminTeacher.LastModifiedAt = DateTime.Now ;
                //adminTeacher.CreatedBy = adminTeacher.ModifiedBy =  adminTeacher.Id;
                await dbContext.AdminTeachers.AddAsync(adminTeacher);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPut]
        //[Route("PutAdminTeachers")]
        //public async Task<ActionResult> PutAdminTeacher(AdminTeacherCreate adminTeacherCreate)
        //{
        //    try
        //    {
        //        var existingUser = await dbContext.AdminTeachers.Where(u => u.Email == adminTeacherCreate.Email).FirstOrDefaultAsync();
        //        if (existingUser != null)
        //        {
        //            return Ok("email already exists");
        //        }
        //        AdminTeacher adminTeacher = AdminTeacherMapper.Map(adminTeacherCreate);
        //        adminTeacher.Id = Guid.NewGuid();
        //        adminTeacher.CreatedAt = adminTeacher.LastModifiedAt = DateTime.Now;
        //        adminTeacher.CreatedBy = adminTeacher.ModifiedBy = adminTeacher.Id;
        //        await dbContext.AdminTeachers.AddAsync(adminTeacher);
        //        await dbContext.SaveChangesAsync();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}


        ////[HttpDelete]
        ////[Route("DeleteUserDetail{id:guid}")]
        ////public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        ////{
        ////    var userDetail = await dbContext.Users.FindAsync(id);

        ////    if (userDetail != null)
        ////    {
        ////        dbContext.Remove(userDetail);
        ////        await dbContext.SaveChangesAsync();

        ////        return Ok();
        ////    }
        ////    return NotFound();
        ////}
    }
}
