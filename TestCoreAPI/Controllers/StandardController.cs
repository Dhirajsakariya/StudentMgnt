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
        [Route("GetStandards")]
        public async Task<ActionResult<IEnumerable<StandardDto>>> GetStandards()
        {
            var standard = await dbContext.Standards.ToListAsync();
            return standard.Select(s => StandardMapper.MapToDto(s)).ToList();
        }

        [HttpGet]
        [Route("GetStandard{id}")]
        public async Task<ActionResult<StandardDto>> GetAdminTeacher(Guid id)
        {
            var standard = await dbContext.Standards.FindAsync(id);

            if (standard == null)
            {
                return NotFound();
            }

            return StandardMapper.MapToDto(standard);
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
                  
               StandardMapper.MapToEntity(standardUpdate,standard);

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
