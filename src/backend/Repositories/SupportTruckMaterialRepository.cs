using BackendECOTVOS.Data.Context;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories
{
    public class SupportTruckMaterialRepository : ISupportTruckMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public SupportTruckMaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddSupportTruckMaterial(SupportTruckMaterial supportTruckMaterial)
        {
            try
            {
                await _context.Support_Truck_Materials.AddAsync(supportTruckMaterial);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get support truck material (Repository). Exception: " + e.Message);
                throw;
            };
        }

        public async Task<SupportTruckMaterial> GetSupportTruckMaterial(MaterialAssignmentViewModel matAssingVM)
        {
            try
            {
                return await _context.Support_Truck_Materials.FirstOrDefaultAsync(
                    i => i.VehicleId == matAssingVM.VehicleId && i.MaterialId == matAssingVM.MaterialId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get support truck material (Repository). Exception: " + e.Message);
                throw;
            };
        }

        public void RemoveSupportTruckMaterial(SupportTruckMaterial sup)
        {
            try
            {
                _context.Support_Truck_Materials.Remove(sup);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to remove support truck material (Repository). Exception: " + e.Message);
                throw;
            };
        }
    }
}
