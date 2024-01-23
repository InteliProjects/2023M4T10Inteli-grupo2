namespace BackendECOTVOS.Domain.DTOs
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Branch { get; set; }
    }
}
