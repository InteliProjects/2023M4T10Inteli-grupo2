using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services.Interfaces
{
    public interface IOperationService
    {
        public Task<int> AddOperation(OperationViewModel opVM);
        public Task<IEnumerable<OperationDTO>> GetAllOperations();
        public Task<IEnumerable<OperationDTO>> GetFinishedOperations();
        public Task<IEnumerable<OperationDTO>> GetLostOperations();
        public Task<IEnumerable<OperationDTO>> GetActiveOperations();
        public Task<Operation> GetOperationById(int id);
        public Task UpdateOperationStatus(int id, char status);
    }
}
