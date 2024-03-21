using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.UpdateModel
{
    [NotMapped]
    public class StandardUpdate
    {  
        public  int StandardNumber { get; set; }
        public  string Section { get; set; }
    }
}
