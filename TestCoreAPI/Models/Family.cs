using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models
{
    public class Family : BaseModel
    {
        public Guid Id { get; set; }
        public required string Relation { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Occupation { get; set; }
        public required string Gender { get; set; }
        public required string MobileNumber { get; set; }
      
        public Guid StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Students { get; set; }

    }
}
