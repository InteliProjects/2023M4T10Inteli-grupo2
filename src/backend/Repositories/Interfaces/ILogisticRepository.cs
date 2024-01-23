using BackendECOTVOS.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface ILogisticRepository
    {
        public Task AddLogistic(Logistic logistic);
        public Task<Logistic> GetLogisticByOperatorId(int operatorId);
        public Task<IEnumerable<Logistic>> GetAllLogistics();
    }
}
