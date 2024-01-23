using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendECOTVOS.Domain.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public required string Description { get; set; }
        public char Type { get; set; }
        public required string Branch { get; set; }

        // Navigation properties
        public ICollection<MaterialAssignment>? Assignments { get; set; }
        public ICollection<Logistic>? Logistics { get; set; }
        public ICollection<SupportTruckMaterial>? SupportTruckMaterial { get; set; }

    }
}
