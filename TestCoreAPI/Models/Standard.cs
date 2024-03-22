 namespace TestCoreApi.Models
{
    public class Standard
    {
        public Guid Id { get; set; }
        public required int StandardNumber {  get; set; }
        public required string Section { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }

        public virtual ICollection<Student> Students {  get; set; }

        public virtual ICollection<AdminTeacher> AdminTeachers { get; set;}
    }
}
