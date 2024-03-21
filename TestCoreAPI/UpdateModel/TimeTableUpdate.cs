using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.UpdateModel
{
    [NotMapped]
    public class TimeTableUpdate
    {
        public int NoOfDay { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
