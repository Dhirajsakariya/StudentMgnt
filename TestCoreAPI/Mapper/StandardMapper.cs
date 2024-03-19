using TestCoreApi.CreateModel;
using TestCoreApi.Models;

namespace TestCoreApi.Mapper
{
    public class StandardMapper
    {
        public static Standard Map(StandardCreate standardCreate)
        {
            return new()
            {
                StandardNumber = standardCreate.StandardNumber,
                Section = standardCreate.Section,
            };

        }
    }
}
