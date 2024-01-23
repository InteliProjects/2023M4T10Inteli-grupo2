namespace BackendECOTVOS.Domain.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Branch { get; set; }
        public required char Type {  get; set; }
    }
}
