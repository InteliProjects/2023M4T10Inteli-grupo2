using BackendECOTVOS.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services.Interfaces
{
    public interface IOperationMaterialsService
    {
        public Task AddOperationMaterial(int operationId, List<int> materialIds);
        public IEnumerable<OperationMaterialsDTO> GetAssociatedMaterialsDescriptionsByOperationIds(List<int> operationId);
    }
}
