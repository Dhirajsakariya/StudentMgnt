﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class AdminTeacherCreate
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Gender { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required string MobileNumber { get; set; }
        public required DateOnly JoinDate { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string District { get; set; }
        public required string State { get; set; }
        public required string PinCode { get; set; }
        public bool IsAdmin { get; set; } = false;
        public Guid? SubjectId { get; set; }

    }
}