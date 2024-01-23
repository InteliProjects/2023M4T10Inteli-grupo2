using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        public Task AddVehicle(Vehicle vehicle);
        public Task<IEnumerable<Vehicle>> GetAllVehicles();
        public Task<Vehicle> GetVehicleById(int id);
    }
}
