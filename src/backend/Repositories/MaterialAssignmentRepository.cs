using BackendECOTVOS.Data.Context;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories
{
    public class MaterialAssignmentRepository : IMaterialAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialAssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MaterialAssignment> GetMaterialAssignment(MaterialAssignmentViewModel matAssign)
        {
            try
            {
                return await _context.Material_Assignments.FirstOrDefaultAsync(i =>
                                                    i.VehicleId == matAssign.VehicleId && i.MaterialId == matAssign.MaterialId);

            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get material assignment (Repository). Exception: " + e.Message);
                throw;
            };
        }

        public async Task AddMaterialAssignment(MaterialAssignment matAssign)
        {
            try
            {
                await _context.Material_Assignments.AddAsync(matAssign);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add material assignment (Repository). Exception: " + e.Message);
                throw;
            };
        }

        public void RemoveMaterialAssignment(MaterialAssignment matAssign)
        {
            try
            {
                _context.Material_Assignments.Remove(matAssign);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to remove material assignment (Repository). Exception: " + e.Message);
                throw;
            };
        }
    }
}
