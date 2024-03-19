using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class SubjectCreate
    {
        public required string Name { get; set; }
        public required Guid StandardId { get; set; }
    }
}
