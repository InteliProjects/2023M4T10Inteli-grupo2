namespace BackendECOTVOS.Domain.DTOs
{
    public class OperatorDTO
    {
        public int Id {  get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
    }
}
