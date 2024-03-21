using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class SubjectCreate
    {  
        public string Name { get; set; }
        public Guid StandardId { get; set; }
    }
}
