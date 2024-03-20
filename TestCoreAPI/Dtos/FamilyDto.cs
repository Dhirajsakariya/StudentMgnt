using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.SignalR;

using TestCoreApi.Models;

namespace TestCoreApi.Dtos
{
    [NotMapped]
    public class FamilyDto
    {
        public Guid Id { get; set; }
        public required string Relation { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Occupation { get; set; }
        public required string Gender { get; set; }
        public required string MobileNumber { get; set; }

        public Guid StudentId { get; set; }

    }
}
