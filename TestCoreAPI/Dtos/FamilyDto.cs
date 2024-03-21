using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.SignalR;

using TestCoreApi.Models;

namespace TestCoreApi.Dtos
{
    [NotMapped]
    public class FamilyDto
    {
        public Guid Id { get; set; }
        public string Relation { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }

        public Guid StudentId { get; set; }

    }
}
