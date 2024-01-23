using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services
{
    public interface IOperatorService
    {
        public Task<int> AddOperator(OperatorViewModel opv);
        public Task<IEnumerable<OperatorDTO>> GetAllOperators();
        public Task<OperatorDTO> GetOperatorById(int id);
        public Task<OperatorDTO> GetOperatorByName(string name);
        public Task UpdateOperator(OperatorDTO op);
        public Task DeleteOperator(int id);
        
    }
}