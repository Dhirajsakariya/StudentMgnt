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
    public class FamilyController : ControllerBase
    {
        private readonly StudentsAPIDbContext dbContext;
        public FamilyController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        [Route("GetFamilyDetail")]
        public async Task<ActionResult<IEnumerable<FamilyDto>>> GetFamily()
        {
            var family= await dbContext.Families.ToListAsync();
            return family.Select(s => FamilyMapper.MapToDto(s)).ToList();
        }

        [HttpGet]
        [Route("GetFamilyDetail{id}")]
        public async Task<ActionResult<FamilyDto>> GetFamily(Guid id)
        {
            var family = await dbContext.Families.FindAsync(id);

            if (family == null)
            {
                return NotFound();
            }

            return FamilyMapper.MapToDto(family);
        }


        
        [HttpPost]
        [Route("PostFamily")]
        public async Task<ActionResult> PostFamily(FamilyCreate familycreate)
        {
            try
            {
                
                Family family = FamilyMapper.Map(familycreate);
                family.Id = Guid.NewGuid();
                await dbContext.Families.AddAsync(family);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutFamily{id}")]
        public async Task<ActionResult> PutFamily(Guid id, FamilyDto familyDto)
        {
            try
            {
                var family = await dbContext.Families.FindAsync(id);

                if (family == null)
                {
                    return NotFound();
                }
                
                family.Relation = familyDto.Relation;
                family.Name = familyDto.Name;
                family.Email = familyDto.Email;
                family.Occupation = familyDto.Occupation;
                family.Gender = familyDto.Gender;
                family.MobileNumber = familyDto.MobileNumber;
                

                dbContext.Entry(family).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(family);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteFamily{id:guid}")]
        public async Task<IActionResult> DeleteFamily([FromRoute] Guid id)
        {
            var family = await dbContext.Families.FindAsync(id);

            if (family != null)
            {
                dbContext.Remove(family);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            return NotFound();
        }
    }
}
