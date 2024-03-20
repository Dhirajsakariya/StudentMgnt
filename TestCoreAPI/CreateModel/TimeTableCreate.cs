using System.ComponentModel.DataAnnotations.Schema;
using TestCoreApi.Models;

namespace TestCoreApi.CreateModel
{
    [NotMapped]  
    public class TimeTableCreate
    {
        public int NoOfDay { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Guid SubjectId { get; set; }
        public Guid StandardId { get; set; }
    }
}
