using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendECOTVOS.Domain.Entities
{
    public class Logistic
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Operator")]
        public int OperatorId { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public string? Front { get; set; }
        public DateOnly Date { get; set; }

        // Navigation properties
        public Operator? Operator { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
