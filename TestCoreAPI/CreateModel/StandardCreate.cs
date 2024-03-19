using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class StandardCreate
    {  
        public required int StandardNumber { get; set; }
        public required string Section { get; set; }
    }
}
