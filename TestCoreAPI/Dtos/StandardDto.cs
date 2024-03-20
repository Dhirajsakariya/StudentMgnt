﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Dtos
{
    [NotMapped]
    public class StandardDto
    {
        public Guid Id { get; set; }
        public required int StandardNumber { get; set; }
        public required string Section { get; set; }
    }
}