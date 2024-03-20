using TestCoreApi.CreateModel;
using TestCoreApi.Dtos;
using TestCoreApi.Models;

namespace TestCoreApi.Mapper
{
    public class FeesMapper
    {
        public static Fees Map(FeesCreate feesCreate)
        {
            return new()
            {
                Amount = feesCreate.Amount,
                StudentId = feesCreate.StudentId,
            };

        }
        public static FeesDto MapToDto(Fees fees)
        {
            return new()
            {
                Id = fees.Id,
                Amount = fees.Amount,
                StudentId = fees.StudentId,
            };

        }
    }
}