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
    public class TimeTableController : ControllerBase
    {
        private readonly StudentsAPIDbContext dbContext;
        public TimeTableController(StudentsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetTimeTables")]
        public async Task<ActionResult<TimeTable>> GetTimeTable()
        {
            return Ok(await dbContext.TimeTables.ToListAsync());
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
        public async Task<ActionResult> PutTimeTable(Guid id, TimeTableDto timeTableDto)
        {
            try
            {
                var timeTable = await dbContext.TimeTables.FindAsync(id);

                if (timeTable == null)
                {
                    return NotFound();
                }
                timeTable.NoOfDay = timeTableDto.NoOfDay;
                timeTable.StartTime = timeTableDto.StartTime;
                timeTable.EndTime = timeTableDto.EndTime;


                dbContext.Entry(timeTable).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(timeTable);

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
