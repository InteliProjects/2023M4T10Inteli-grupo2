using BackendECOTVOS.Domain.ViewModels;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services.Interfaces
{
    public interface IMaterialAssignmentService
    {
        public Task<int> AddMaterialAssignment(MaterialAssignmentViewModel matAssignVM);
        public Task RemoveMaterialAssignment(MaterialAssignmentViewModel matAssignVM);
    }
}
