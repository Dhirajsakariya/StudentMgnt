using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using TestCoreApi.Models;
using TestCoreApi.UpdateModel;

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
                BloodGroup = student.BloodGroup,
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

        public static void MapToEntity(StudentUpdate studentUpdate, Student student)
        {
            student.Name = studentUpdate.Name;
            student.Email = studentUpdate.Email;
            student.Password = studentUpdate.Password;
            student.Gender = studentUpdate.Gender;
            student.BirthDate = studentUpdate.BirthDate;
            student.MobileNumber = studentUpdate.MobileNumber;
            student.BloodGroup = studentUpdate.BloodGroup;
            student.JoinDate = studentUpdate.JoinDate;
            student.Address = studentUpdate.Address;
            student.City = studentUpdate.City;
            student.District = studentUpdate.District;
            student.State = studentUpdate.State;
            student.PinCode = studentUpdate.PinCode;
            // Add other properties as needed
        }
    }
}
