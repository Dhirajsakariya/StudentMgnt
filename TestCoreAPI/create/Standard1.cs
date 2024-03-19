using System.ComponentModel.DataAnnotations.Schema;
namespace TestCoreApi.create
{
    [NotMapped]
    public class Standard1
    {
        public required int StandardNumber { get; set; }
        public required string Section { get; set; }
        public Guid? Id { get; set; }
    }
}
