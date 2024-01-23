using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface ISupportTruckMaterialRepository
    {
        public Task<SupportTruckMaterial> GetSupportTruckMaterial(MaterialAssignmentViewModel matAssignVM);
        public Task AddSupportTruckMaterial(SupportTruckMaterial supportTruckMaterial);
        public void RemoveSupportTruckMaterial(SupportTruckMaterial supportTruckMaterial);
    }
}
