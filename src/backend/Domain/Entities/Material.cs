using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendECOTVOS.Domain.Entities
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Branch { get; set; }
        public bool Assigned { get; set; }

        // Navigation properties
        public ICollection<MaterialAssignment>? Assignments { get; set; }
        public ICollection<SupportTruckMaterial>? SupportTruckMaterials { get; set; }
        public ICollection<OperationMaterials>? OperationMaterials { get; set; }
    }
}
