using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models
{
    public class Subject : BaseModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<AdminTeacher> AdminTeachers { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }

        public required Guid StandardId { get; set; }
        [ForeignKey(nameof(StandardId))]
        public virtual Standard Standards { get; set; }

    }
}