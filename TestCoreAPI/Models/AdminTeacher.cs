using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models
{
   
    public class AdminTeacher
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Gender { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required string MobileNumber { get; set; }
        public required DateOnly JoinDate { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string District {  get; set; }
        public required string State { get; set; }
        public required string PinCode { get; set; }
        public bool IsAdmin { get; set; } = false;
        public Guid? SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subjects { get; set; }

        public virtual ICollection<Fees> CreatorFees { get; set; }
        public virtual ICollection<Fees> ModifierFees { get; set; }

        public virtual ICollection<Family> CreatorFamilies { get; set; }
        public virtual ICollection<Family> ModifierFamilies { get; set; }
        public virtual ICollection<Student> CreatorStudents { get; set; }
        public virtual ICollection<Student> ModifierStudents { get; set; }
        public virtual ICollection<TimeTable> CreatorTimeTable { get; set; }
        public virtual ICollection<TimeTable> ModifierTimeTable { get; set; }
        public virtual ICollection<Standard> CreatorStandard { get; set; }
        public virtual ICollection<Standard> ModifierStandard { get; set; }

    }
}
