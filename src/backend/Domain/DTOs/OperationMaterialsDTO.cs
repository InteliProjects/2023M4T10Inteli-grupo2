using System.Collections.Generic;

namespace BackendECOTVOS.Domain.DTOs
{
    public class OperationMaterialsDTO
    {
        public int OperationId {  get; set; }
        public List<int> MaterialsIds { get; set; }
        public List<string>? MaterialsDescriptions { get; set; }
    }
}
