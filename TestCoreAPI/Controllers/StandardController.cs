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
       
    }
}
