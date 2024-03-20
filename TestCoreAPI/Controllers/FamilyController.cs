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
        public async Task<ActionResult<Family>> GetFamily()
        {
            return Ok(await dbContext.Families.ToListAsync());
        }

        [HttpPost]
        [Route("PostFamily")]
        public async Task<ActionResult> PostFamily(FamilyCreate familycreate)
        {
            try
            {
                var existinguser = await dbContext.Families.Where(u => u.Email == familycreate.Email).FirstOrDefaultAsync();
                if (existinguser != null)
                {
                    return Ok("email already exists");
                }
                Family family = FamilyMapper.Map(familycreate);
                family.Id = Guid.NewGuid();
                //family.createdat = family.lastmodifiedat = datetime.now ;
                //family.createdby = family.modifiedby =  family.id;
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
                family.Id = familyDto.Id;
                family.Relation = familyDto.Relation;
                family.Name = familyDto.Name;
                family.Email = familyDto.Email;
                family.Occupation = familyDto.Occupation;
                family.Gender = familyDto.Gender;
                family.MobileNumber = familyDto.MobileNumber;
                family.StudentId = familyDto.StudentId;


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
