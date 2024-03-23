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
        public async Task<ActionResult<Fees>> GetFees()
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
                
                // Check if FeeFrequencies is provided and not null or empty
                if (string.IsNullOrWhiteSpace(feesCreate.FeeFrequency))
                {
                    return BadRequest("FeeFrequencies is required.");
                }

                // Set the fee amount based on the selected fee frequency
                if (feesCreate.FeeFrequency.Equals("Quaterly", StringComparison.OrdinalIgnoreCase))
                {
                    fees.Amount = CalculateQuaterlyAmount(feesCreate.Amount);
                }
                else if (feesCreate.FeeFrequency.Equals("Annually", StringComparison.OrdinalIgnoreCase))
                {
                    fees.Amount = CalculateAnnuallyAmount(feesCreate.Amount);
                }
                else
                {
                    return BadRequest("Invalid Fee Frequency. Please choose Quaterly or Annually.");
                }
                
                await dbContext.Fees.AddAsync(fees);
                await dbContext.SaveChangesAsync();

                var FeesDto = FeesMapper.MapToDto(fees);

                return Ok(FeesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        

         long CalculateQuaterlyAmount(long amount)
        {
            // Calculate Quaterly amount based on the given amount
            // Assuming Quaterly amount is 4 times the given amount
            long quarterlyAmount = amount / 2;
            return quarterlyAmount;
        }
         long CalculateAnnuallyAmount(long amount)
        {
            // Calculate Annually amount based on the given amount
            // Example calculation logic:
            long annuallyAmount = amount ;
            return annuallyAmount;
        }
    }
        [HttpGet]
        [Route("GetFeeAmount/{studentId}")]
        public async Task<ActionResult<long>> GetFeeAmount(Guid studentId)
        {
            try
            {
                // Fetch the Student entry from the Student table based on the StudentId
                var student = await dbContext.Students
                    .Include(s => s.Standards) // Include the Standards navigation property
                    .FirstOrDefaultAsync(s => s.Id == studentId);

                if (student == null)
                {
                    return NotFound("Student entry not found in the Student table.");
                }

                // Extract the StandardId from the Student entry
                var standardId = student.Standards?.Id;
                var standardNumber = student.Standards?.StandardNumber;
                if (standardId == null)
                {
                    return BadRequest("StandardId not found for the student.");
                }

                // Fetch the Standard entry from the Standard table using the StandardId
                var standard = await dbContext.Standards
                    .FirstOrDefaultAsync(s => s.Id == standardId);
                var standarddd = await dbContext.Standards
                    .FirstOrDefaultAsync(s => s.StandardNumber == standardNumber);

                if (standard == null)
                {
                    return BadRequest("Standard entry not found in the Standard table.");
                }

                // Fetch the FeesMaster entry from the FeesMaster table where StandardNumber matches
                var feesMaster = await dbContext.FeesMasters
                    .FirstOrDefaultAsync(s => s.StandardNumber == s.StandardNumber);

                if (feesMaster == null)
                {
                    return BadRequest("FeesMaster entry not found for the StandardNumber.");
                }

                // Return the fee amount (FeesAmount) from FeesMaster
                return Ok(feesMaster.Amount);
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


