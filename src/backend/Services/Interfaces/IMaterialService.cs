using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services.Interfaces
{
    public interface IMaterialService
    {
        public Task<int> AddMaterial(MaterialViewModel material);
        public Task<IEnumerable<MaterialDTO>> GetAllUnassignedMaterials();
        public Task<Material> GetMaterialById(int id);
        public Task UpdateMaterialAssigned(int id, bool assigned);
        public IEnumerable<OperationMaterialsDTO> GetOperationMaterialsDTODescriptions(IEnumerable<OperationMaterialsDTO> opMatsDTO);
    }
}
