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
    public class TimeTableController : ControllerBase
    {
        private readonly StudentsAPIDbContext dbContext;
        public TimeTableController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetTimeTables")]
        public async Task<ActionResult<IEnumerable<TimeTableDto>>> GetTimeTables()
        {
            var timeTable = await dbContext.TimeTables.ToListAsync();
            return timeTable.Select(s => TimeTableMapper.MapToDto(s)).ToList();
        }

        [HttpGet]
        [Route("GetTimeTable{id}")]
        public async Task<ActionResult<TimeTableDto>> GetTimeTable(Guid id)
        {
            var timeTable = await dbContext.TimeTables.FindAsync(id);

            if (timeTable == null)
            {
                return NotFound();
            }

            return TimeTableMapper.MapToDto(timeTable);
        }

        [HttpPost]
        [Route("PostTimeTable")]
        public async Task<ActionResult> PostTimeTable(TimeTableCreate timeTableCreate)
        {
            try
            {
                TimeTable timetable = TimeTableMapper.Map(timeTableCreate);

                var standard = dbContext.Standards.Where(x => x.StandardNumber == timeTableCreate.StandardNumber && x.Section.ToLower() == timeTableCreate.Section.ToLower()).FirstOrDefault();
                if(standard == null)
                {
                    return BadRequest("Invalid StandardId. Standard with the provided Id does not exist.");
                }
                timetable.StandardId = standard.Id;

                var subject = dbContext.Subjects.Where(x => x.Name.ToLower() == timeTableCreate.SubjectName.ToLower()).FirstOrDefault();
                if(subject == null)
                {
                    return BadRequest("Invalid SubjectId. Standard with the provided Id does not exist.");
                }
                timetable.SubjectId = subject.Id;
                timetable.Id = Guid.NewGuid();
                await dbContext.TimeTables.AddAsync(timetable);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
             
        [HttpPut]
        [Route("PutTimeTable{id}")]
        public async Task<ActionResult> PutTimeTable(Guid id, TimeTableUpdate timeTableUpdate)
        {
            try
            {
                var timeTable = await dbContext.TimeTables.FindAsync(id);

                if (timeTable == null)
                {
                    return NotFound();
                }

                TimeTableMapper.MapToEntity(timeTableUpdate, timeTable);
                dbContext.Entry(timeTable).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(timeTableUpdate);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTimeTable{id:guid}")]
        public async Task<IActionResult> TimeTable([FromRoute] Guid id)
        {
            var timeTable = await dbContext.TimeTables.FindAsync(id);

            if (timeTable != null)
            {
                dbContext.Remove(timeTable);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            return NotFound();
        }
    }
}
