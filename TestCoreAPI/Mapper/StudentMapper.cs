using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using TestCoreApi.Models;

namespace TestCoreApi.Mapper
{
    public class StudentMapper
    {
        public static Student Map(StudentCreate studentCreate)
        {
            return new()
            {
                Name = studentCreate.Name,
                Email = studentCreate.Email,
                Password = studentCreate.Password,
                Gender = studentCreate.Gender,
                BirthDate = studentCreate.BirthDate,
                MobileNumber = studentCreate.MobileNumber,
                JoinDate = studentCreate.JoinDate,
                BloodGroup = studentCreate.BloodGroup,
                Address = studentCreate.Address,
                City = studentCreate.City,
                District = studentCreate.District,
                State = studentCreate.State,
                PinCode = studentCreate.PinCode,
                StandardId = studentCreate.StandardId,
            };
        }
        public static StudentDto MapToDto(Student student)
        {
            return new()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Password = student.Password,
                Gender = student.Gender,
                BirthDate = student.BirthDate,
                MobileNumber = student.MobileNumber,
                JoinDate = student.JoinDate,
                Address = student.Address,
                City = student.City,
                District = student.District,
                State = student.State,
                PinCode = student.PinCode,
                // Add other properties as needed
                StandardId = student.StandardId,
            };
        }

        public static void MapToEntity(StudentDto studentDto, Student student)
        {
            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.Password = studentDto.Password;
            student.Gender = studentDto.Gender;
            student.BirthDate = studentDto.BirthDate;
            student.MobileNumber = studentDto.MobileNumber;
            student.JoinDate = studentDto.JoinDate;
            student.Address = studentDto.Address;
            student.City = studentDto.City;
            student.District = studentDto.District;
            student.State = studentDto.State;
            student.PinCode = studentDto.PinCode;
            // Add other properties as needed
        }
    }
}
