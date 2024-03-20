using TestCoreApi.CreateModel;
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
    }
}
