using System.ComponentModel.DataAnnotations.Schema;

using TestCoreApi.Models;

namespace TestCoreApi.Dtos
{
    [NotMapped]
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required Guid StandardId { get; set; }
    }
}
