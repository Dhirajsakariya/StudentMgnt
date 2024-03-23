using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Dtos
{
    [NotMapped]
    public class FeesDto
    { 
        public Guid Id { get; set; }
        public string? FeeFrequency { get; set; }
        public long Amount { get; set; }

        public Guid StudentId { get; set; }
    }
}
