using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface IOperatorRepository
    {
        public Task<IEnumerable<OperatorDTO>> GetAllOperators();
        public Task<Operator> GetOperatorById(int id);
        public Task<OperatorDTO> GetOperatorByName(string name);
        public Task AddOperator(Operator op);   
        public void UpdateOperator(Operator op, Operator opNewData);
        public void DeleteOperator(int id); 
    }
}
