using BackendECOTVOS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface IOperationMaterialsRepository
    {
        public Task AddOperationMaterial(int operationId, List<int> materialIds);
        public IEnumerable<OperationMaterials> GetOperationMaterialsByOperationIds(List<int> operationIds);
    }
}
