using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public int RollNo {  get; set; } 
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Gender { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required string MobileNumber { get; set; }
        public required DateOnly JoinDate { get; set; }
        public string? BloodGroup { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string District { get; set; }
        public required string State { get; set; }
        public required string PinCode { get; set; }

        public virtual ICollection<Family> Families { get; set; }
        public virtual ICollection<Fees>Fees { get; set; }

        public Guid StandardId { get; set; }
        [ForeignKey(nameof(StandardId))]
        public virtual Standard Standards { get; set; }

    }
}
