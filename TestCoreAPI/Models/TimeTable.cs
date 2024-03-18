using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models
{
    public class TimeTable : BaseModel
    {
        public Guid Id { get; set; }  
        public int NoOfDay { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set;}
        public Guid SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subjects { get; set; }

        public Guid StandardId { get; set; }
        [ForeignKey(nameof(StandardId))]
        public virtual Standard Standards { get; set; }


    }
}
