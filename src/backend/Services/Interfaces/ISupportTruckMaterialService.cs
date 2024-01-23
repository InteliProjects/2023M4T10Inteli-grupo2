using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services.Interfaces
{
    public interface ISupportTruckMaterialService
    {
        public Task<SupportTruckMaterial> GetSupportTruckMaterial(MaterialAssignmentViewModel materialAssignmentVM);
        public Task<int> AddSupportTruckMaterial(MaterialAssignmentViewModel matAssignVM);
        public Task RemoveSupportTruckMaterial(MaterialAssignmentViewModel matAssignVM);
    }
}
