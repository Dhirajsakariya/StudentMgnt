using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class StandardCreate
    {  
        public int StandardNumber { get; set; }
        public string Section { get; set; }
    }
}
