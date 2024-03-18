﻿namespace TestCoreApi.Models
{
    public class Standard : BaseModel
    {
        public Guid Id { get; set; }
        public required int StandardNumber {  get; set; }
        public required string Section { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }

        public virtual ICollection<Student> Students {  get; set; }

    }
}
