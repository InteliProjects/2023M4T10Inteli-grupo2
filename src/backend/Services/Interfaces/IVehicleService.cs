using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services.Interfaces
{
    public interface IVehicleService

    {
        public Task<int> AddVehicle(VehicleViewModel vehicle);
        public Task<IEnumerable<VehicleDTO>> GetAllVehicles();
        public Task<VehicleDTO> GetVehicleById(int id);
    }
}
