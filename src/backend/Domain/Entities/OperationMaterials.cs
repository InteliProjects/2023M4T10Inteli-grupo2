using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendECOTVOS.Domain.Entities
{
    public class OperationMaterials
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Operation")]
        public int OperationId { get; set; }

        [ForeignKey("Material")]
        public int AssociatedMaterialId { get; set; }

        public bool Defective { get; set; }

        // Navigation properties
        public Operation? Operation { get; set; }
        public Material? Material { get; set; }

    }
}
