using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using TestCoreApi.Models;
using TestCoreApi.UpdateModel;

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

        public static void MapToEntity(FamilyUpdate familyUpdate, Family family)
        {
            {
                family.Relation = familyUpdate.Relation;
                family.Name = familyUpdate.Name;
                family.Email = familyUpdate.Email;
                family.Occupation = familyUpdate.Occupation;
                family.Gender = familyUpdate.Gender;
                family.MobileNumber = familyUpdate.MobileNumber;
            }

        }

    }
}
