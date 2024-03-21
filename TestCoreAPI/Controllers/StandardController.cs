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
    public class StandardController : ControllerBase
    {

        private readonly StudentsAPIDbContext dbContext;
        public StandardController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetStanadard")]
        public async Task<ActionResult<Standard>> GetStanadard()
        {
            return Ok(await dbContext.Standards.ToListAsync());
        }

        [HttpPost]
        [Route("PostStanadard")]
        public async Task<ActionResult> PostStanadard(StandardCreate standardCreate)
        {
            try
            {
                Standard standard = StandardMapper.Map(standardCreate);
                standard.Id = Guid.NewGuid();
                await dbContext.Standards.AddAsync(standard);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutStandard{id}")]
        public async Task<ActionResult> PutStandard(Guid id, StandardUpdate standardUpdate)
        {
            try
            {
                var standard = await dbContext.Standards.FindAsync(id);

                if (standard == null)
                {
                    return NotFound();
                }

               StandardMapper.MapToEntity(standardUpdate);

                dbContext.Entry(standard).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(standardUpdate);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteStandard{id:guid}")]
        public async Task<IActionResult> DeleteStandard([FromRoute] Guid id)
        {
            var standard = await dbContext.Standards.FindAsync(id);

            if (standard != null)
            {
                dbContext.Remove(standard);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            return NotFound();
        }

    }
}
