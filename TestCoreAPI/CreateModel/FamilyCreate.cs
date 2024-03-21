using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.CreateModel
{
    [NotMapped]
    public class FamilyCreate
    {   
        public string Relation { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }

        public Guid StudentId { get; set; }
    }
}
