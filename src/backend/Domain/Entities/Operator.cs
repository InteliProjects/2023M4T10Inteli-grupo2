using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendECOTVOS.Domain.Entities
{
    public class Operator
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }

        // Navigation properties
        public ICollection<Logistic>? Logistics { get; set; }

    }
}