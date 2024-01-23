using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        public Task AddMaterial(Material material);
        public Task<IEnumerable<Material>> GetAllUnassignedMaterials();
        public Task<Material> GetMaterialById(int id);
        public void UpdateMaterialAssigned(Material material, bool assigned);
        public List<string> GetMaterialsDescriptionsByIds(IEnumerable<int> matsIds);
    }
}
