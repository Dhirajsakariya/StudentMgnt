using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using TestCoreApi.Models;

namespace TestCoreApi.Mapper
{
    public class FamilyMapper
    {
        public static Family Map(FamilyCreate familyCreate)
        {
            return new()
            {
                Relation = familyCreate.Relation,
                Name = familyCreate.Name,
                Email = familyCreate.Email,
                Occupation = familyCreate.Occupation,
                Gender = familyCreate.Gender,
                MobileNumber = familyCreate.MobileNumber,
                StudentId = familyCreate.StudentId,
            };
      }

        public static FamilyDto MapToDto(Family family)
        {
            return new()
            {
                Id = family.Id,
                Relation = family.Relation,
                Name = family.Name,
                Email = family.Email,
                Occupation = family.Occupation,
                Gender = family.Gender,
                MobileNumber = family.MobileNumber,
                StudentId = family.StudentId,

            };
        }

     }
}
