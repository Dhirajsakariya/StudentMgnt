using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class FeesCreate
    { 
        public long Amount { get; set; }

        public Guid StudentId { get; set; }
    }
}
