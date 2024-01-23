using BackendECOTVOS.Data.Context;
using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMaterial(Material material)
        {
            try
            {
                await _context.Materials.AddAsync(material);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add material (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Material>> GetAllUnassignedMaterials()
        {
            try
            {
                List<Material>? materials = await _context.Materials.Where(i => i.Assigned == false).ToListAsync();

                return materials;

            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all unassigned materials (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<Material> GetMaterialById(int id)
        {
            try
            {
                return await _context.Materials.FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get material by id (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public List<string> GetMaterialsDescriptionsByIds(IEnumerable<int> matsIds)
        {
            try
            {
                return _context.Materials.ToList().Join(
                    matsIds, mat => mat.Id, id => id, (mat, id) => mat.Description).ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to get materials descriptions by ids (Repository). Exception: " + e.Message);
                throw;
            }
            
        }

        public void UpdateMaterialAssigned(Material material, bool assigned)
        {
            try
            {
                Material reassignedMaterial = material;

                reassignedMaterial.Assigned = assigned;
            
                _context.Materials.Entry(material).CurrentValues.SetValues(assigned);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to update material assigned (Repository). Exception: " + e.Message);
                throw;
            }
        }
    }
}
