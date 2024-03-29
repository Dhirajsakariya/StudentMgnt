﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.Models
{
    public class Fees 
    {
        public Guid Id { get; set; }
        public  string? FeeFrequency { get; set; }
       
        public long  Amount { get; set; }

        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]

        public virtual Student Student { get; set; }

    }
}
