using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Repositories.Interfaces;
using BackendECOTVOS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services
{
    public class MaterialAssignmentService : IMaterialAssignmentService
    {
        private readonly IMaterialAssignmentRepository _materialAssignmentRepository;
        private readonly IMaterialService _materialService;
        private readonly IVehicleService _vehicleService;
        private readonly ISupportTruckMaterialService _supportTruckMaterialService;
        private readonly IUnitOfWork _uow;

        public MaterialAssignmentService(IMaterialAssignmentRepository materialAssignmentRepository, IMaterialService materialService,
            IVehicleService vehicleService, ISupportTruckMaterialService supportTruckMaterialService, IUnitOfWork uow)
        {
            _materialAssignmentRepository = materialAssignmentRepository;
            _materialService = materialService;
            _vehicleService = vehicleService;
            _supportTruckMaterialService = supportTruckMaterialService;
            _uow = uow;
        }
        public async Task<int> AddMaterialAssignment(MaterialAssignmentViewModel matAssignVM)
        {
            try
            {
                MaterialAssignment materialAssignment = new MaterialAssignment()
                {
                    MaterialId = matAssignVM.MaterialId,
                    VehicleId = matAssignVM.VehicleId
                };

                await _materialAssignmentRepository.AddMaterialAssignment(materialAssignment);

                await _materialService.UpdateMaterialAssigned(materialAssignment.MaterialId, true);
                
                await _uow.Commit();
                
                return materialAssignment.Id;
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Failed to add material assignment (Service). Exception: " + e);
                throw;
            }
        }

        public async Task RemoveMaterialAssignment(MaterialAssignmentViewModel matAssignVM)
        {
            try
            {
                MaterialAssignment mat = await _materialAssignmentRepository.GetMaterialAssignment(matAssignVM) ??
                    throw new Exception("Failed to get material assignment (null)");

                _materialAssignmentRepository.RemoveMaterialAssignment(mat);

                await _materialService.UpdateMaterialAssigned(mat.MaterialId, false);

                await _uow.Commit();
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to remove material assignment (Service). Exception: " + e);
                throw;
            }
        }
    }
}
