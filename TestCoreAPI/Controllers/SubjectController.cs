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
    public class SubjectController : ControllerBase
    {
        private readonly StudentsAPIDbContext dbContext;
        public SubjectController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetSubjects")]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetSubjects()
        {
            var subject = await dbContext.Subjects.ToListAsync();
            return subject.Select(s => SubjectMapper.MapToDto(s)).ToList();
        }

        [HttpGet]
        [Route("GetSubject{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubject(Guid id)
        {
            var subject = await dbContext.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return SubjectMapper.MapToDto(subject);
        }

        [HttpPost]
        [Route("PostSubjects")]
        public async Task<ActionResult> PostSubjects(SubjectCreate subjectCreate)
        {
            try
            {
                Subject subject = SubjectMapper.Map(subjectCreate);
                subject.Id = Guid.NewGuid();
                await dbContext.Subjects.AddAsync(subject);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("PutSubject{id}")]
        public async Task<ActionResult> PutSubject(Guid id, SubjectUpdate subjectUpdate)
        {
            try
            {
                var subject = await dbContext.Subjects.FindAsync(id);

                if (subject == null)
                {
                    return NotFound();
                }
                

                SubjectMapper.MapToEntity(subjectUpdate, subject);

                

                dbContext.Entry(subject).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(subjectUpdate);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteSubject{id:guid}")]
        public async Task<IActionResult> DeleteSubject([FromRoute] Guid id)
        {
            var subject = await dbContext.Subjects.FindAsync(id);

            if (subject != null)
            {
                dbContext.Remove(subject);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            return NotFound();
        }
    }
}
