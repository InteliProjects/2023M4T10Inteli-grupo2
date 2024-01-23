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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddVehicle(Vehicle vehicle)
        {
            try
            {
                await _context.Vehicles.AddAsync(vehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add material (Repository). Exception: " + e.Message);
                throw;
            }

        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            try
            {
                IEnumerable<Vehicle> vehicles = await _context.Vehicles
                       .Select(v => new Vehicle
                       {
                           Id = v.Id,
                           Description = v.Description,
                           Type = v.Type,
                           Branch = v.Branch
                       })
                       .ToListAsync();
                return (IEnumerable<Vehicle>)vehicles;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all vehicles (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            try
            {
                return await _context.Vehicles.FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get vehicle by id (Repository). Exception: " + e.Message);
                throw;
            }
        }
    }
}

