using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using System.Net.Http.Headers;

using TestCoreApi.Models;
using TestCoreApi.UpdateModel;

namespace TestCoreApi.Mapper
{  
    public class AdminTeacherMapper
    {
        public static AdminTeacher Map(AdminTeacherCreate adminTeacherCreate)
        {
            return new()
            {
                Name = adminTeacherCreate.Name,
                Email = adminTeacherCreate.Email,
                Password = adminTeacherCreate.Password,
                Gender = adminTeacherCreate.Gender,
                BirthDate = adminTeacherCreate.BirthDate,
                MobileNumber = adminTeacherCreate.MobileNumber,
                JoinDate = adminTeacherCreate.JoinDate,
                Address = adminTeacherCreate.Address,
                City = adminTeacherCreate.City,
                District = adminTeacherCreate.District,
                State = adminTeacherCreate.State,
                PinCode = adminTeacherCreate.PinCode,
                IsAdmin = adminTeacherCreate.IsAdmin,
                //SubjectId = adminTeacherCreate.SubjectId,
            };

        }

        public static AdminTeacherDto MapToDto(AdminTeacher adminTeacher)
        {
            return new()
            {
                Id = adminTeacher.Id,
                Name = adminTeacher.Name,
                Email = adminTeacher.Email,
                Password = adminTeacher.Password,
                Gender = adminTeacher.Gender,
                BirthDate = adminTeacher.BirthDate,
                MobileNumber = adminTeacher.MobileNumber,
                JoinDate = adminTeacher.JoinDate,
                Address = adminTeacher.Address,
                City = adminTeacher.City,
                District = adminTeacher.District,
                State = adminTeacher.State,
                PinCode = adminTeacher.PinCode,
                IsAdmin = adminTeacher.IsAdmin,
                SubjectId = adminTeacher.SubjectId,
                StandardId = adminTeacher.StandardId,
            };
        }

        public static void MapToEntity(AdminTeacherUpdate adminTeacherUpdate, AdminTeacher adminTeacher)
        {
            {
                adminTeacher.Name = adminTeacherUpdate.Name;
                adminTeacher.Email = adminTeacherUpdate.Email;
                adminTeacher.Password = adminTeacherUpdate.Password;
                adminTeacher.Gender = adminTeacherUpdate.Gender;
                adminTeacher.BirthDate = adminTeacherUpdate.BirthDate;
                adminTeacher.MobileNumber = adminTeacherUpdate.MobileNumber;
                adminTeacher.JoinDate = adminTeacherUpdate.JoinDate;
                adminTeacher.Address = adminTeacherUpdate.Address;
                adminTeacher.City = adminTeacherUpdate.City;
                adminTeacher.District = adminTeacherUpdate.District;
                adminTeacher.State = adminTeacherUpdate.State;
                adminTeacher.PinCode = adminTeacherUpdate.PinCode;
                adminTeacher.IsAdmin = adminTeacherUpdate.IsAdmin;
            };

        }
    }
}
