using System.ComponentModel.DataAnnotations.Schema;

using TestCoreApi.Models;

namespace TestCoreApi.Dtos
{
    [NotMapped]
    public class SubjectDto
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StandardId { get; set; }
    }
}
