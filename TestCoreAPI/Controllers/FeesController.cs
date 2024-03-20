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
    public class FeesController : ControllerBase
    {
        private readonly StudentsAPIDbContext dbContext;
        public FeesController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetFees")]
        public async Task<ActionResult<AdminTeacher>> GetFees()
        {
            return Ok(await dbContext.Fees.ToListAsync());
        }
        [HttpPost]
        [Route("PostFees")]
        public async Task<ActionResult> PostFees(FeesCreate feesCreate)
        {
            try
            {
                Fees fees = FeesMapper.Map(feesCreate);
                fees.Id = Guid.NewGuid();
                await dbContext.Fees.AddAsync(fees);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("PutFees{id}")]
        public async Task<ActionResult> PutFees(Guid id, FeesDto feesDto)
        {
            try
            {
                var fees = await dbContext.Fees.FindAsync(id);

                if (fees == null)
                {
                    return NotFound();
                }
                fees.Amount = feesDto.Amount;
                fees.StudentId = feesDto.StudentId;

                dbContext.Entry(fees).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(feesDto);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteFees{id:guid}")]
        public async Task<IActionResult> DeleteFees([FromRoute] Guid id)
        {
            var fees = await dbContext.Fees.FindAsync(id);

            if (fees != null)
            {
                dbContext.Remove(fees);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            return NotFound();
        }
    }
}
