using TestCoreApi.CreateModel;
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
    }
}