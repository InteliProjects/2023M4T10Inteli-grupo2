using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface IMaterialAssignmentRepository
    {
        public Task AddMaterialAssignment(MaterialAssignment matAssign);
        public void RemoveMaterialAssignment(MaterialAssignment matAssign);
        public Task<MaterialAssignment> GetMaterialAssignment(MaterialAssignmentViewModel matAssign);

    }
}
