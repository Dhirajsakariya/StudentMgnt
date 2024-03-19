using TestCoreApi.CreateModel;
using TestCoreApi.Models;

namespace TestCoreApi.Mapper
{
    public class SubjectMapper
    {
        public static Subject Map(SubjectCreate subjectCreate)
        {
            return new()
            {
                Name = subjectCreate.Name,
                StandardId = subjectCreate.StandardId,
            };

        }
    }
}
