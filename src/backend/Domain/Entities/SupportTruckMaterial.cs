using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendECOTVOS.Domain.Entities
{
    public class SupportTruckMaterial
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [ForeignKey("Material")]
        public int MaterialId { get; set; }

        // Navigation properties
        public Vehicle? Vehicle { get; set; }
        public Material? Material { get; set; }

    }
}
