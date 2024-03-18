using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models
{
    [NotMapped]
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual AdminTeacher? Creator { get; set; }
        public virtual AdminTeacher? Modifier { get; set; }

    }
}
