using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Dtos
{
    [NotMapped]
    public class StandardDto
    {
        public Guid Id { get; set; }
        public int StandardNumber { get; set; }
        public string Section { get; set; }
    }
}
