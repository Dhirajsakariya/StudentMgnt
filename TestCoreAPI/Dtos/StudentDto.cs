using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Dtos
{
    [NotMapped]
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string GrNo { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly JoinDate { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public Guid StandardId { get; set; }
    }
}
