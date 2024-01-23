using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Repositories.Interfaces;
using BackendECOTVOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _uow;

        public VehicleService(IVehicleRepository vehicleRepository, IUnitOfWork uow)
        {
            _vehicleRepository = vehicleRepository;
            _uow = uow;
        }

        public async Task<int> AddVehicle(VehicleViewModel vehicle)
        {
            try
            {
                Vehicle newVehicle = new Vehicle()
                {
                    Description = vehicle.Description,
                    Type = vehicle.Type,
                    Branch = vehicle.Branch
                };

                await _vehicleRepository.AddVehicle(newVehicle);
                
                await _uow.Commit();
                
                return newVehicle.Id;
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to add vehicle (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllVehicles()
        {
            try
            {
                IEnumerable<Vehicle> vehicles = await _vehicleRepository.GetAllVehicles() ??
                    throw new Exception("Failed to get all vehicles (null).");

                List<VehicleDTO> vehiclesDTO = vehicles.Select(i => new VehicleDTO()
                {
                    Id = i.Id,
                    Description = i.Description,
                    Type = i.Type,
                    Branch = i.Branch
                }).ToList();

                return vehiclesDTO;
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to get material by id (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<VehicleDTO> GetVehicleById(int id)
        {
            try
            {
                Vehicle vehicle = await _vehicleRepository.GetVehicleById(id) ??
                    throw new Exception("Failed to get vehicle by id (null).");

                VehicleDTO vehicleDTO = new VehicleDTO()
                {
                    Id = vehicle.Id,
                    Description = vehicle.Description,
                    Type = vehicle.Type,
                    Branch = vehicle.Branch
                };

                return vehicleDTO;
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to get vehicle by id (Service). Exception: " + e.Message);
                throw;
            }
        }
    }
}
