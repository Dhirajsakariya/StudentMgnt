using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class FeesCreate
    { 
        public string? FeeFrequency { get; set; }
        public long Amount { get; set; }

        public Guid StudentId { get; set; }
    }
}
