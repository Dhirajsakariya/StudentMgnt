﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class AdminTeacherCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public DateOnly JoinDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public bool IsAdmin { get; set; } = false;
        public string SubjectName { get; set; }
        public int StandardNumber { get; set; }
        public string Section { get; set; }  
    }
}
