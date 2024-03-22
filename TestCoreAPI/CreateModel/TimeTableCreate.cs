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
        public string SubjectName { get; set; }
        public int StandardNumber { get; set; }
        public string Section { get; set; }

    }
}
