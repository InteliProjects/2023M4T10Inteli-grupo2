using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface IOperationRepository
    {
        public Task<IEnumerable<OperationDTO>> GetAllOperations();
        public Task<IEnumerable<OperationDTO>> GetOperationsByStatus(char status);
        public Task<Operation> GetOperationById(int id);
        public Task AddOperation(Operation op);
        public void UpdateOperationStatus(Operation op, char status);
        public Task<List<int>> GetAllOperationsIds();
        public Task<List<int>> GetAllOperationsIdsByStatus(char status);
    }
}
