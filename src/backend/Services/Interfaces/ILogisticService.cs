using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services.Interfaces
{
    public interface ILogisticService
    {
        public Task<int> AddLogistic(LogisticViewModel log);
        public Task<Logistic> GetLogisticByOperatorId(int operatorId);
        public Task<IEnumerable<Logistic>> GetAllLogistics();
    }
}
