using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Repositories.Interfaces;
using BackendECOTVOS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services
{
    public class SupportTruckMaterialService : ISupportTruckMaterialService
    {
        private readonly ISupportTruckMaterialRepository _supportTruckMaterialRepository;
        private readonly IMaterialService _materialService;
        private readonly IUnitOfWork _uow;

        public SupportTruckMaterialService(ISupportTruckMaterialRepository supportTruckMaterialRepository, IMaterialService materialService, IUnitOfWork uow)
        {
            _supportTruckMaterialRepository = supportTruckMaterialRepository;
            _materialService = materialService;
            _uow = uow;
        }

        public async Task<int> AddSupportTruckMaterial(MaterialAssignmentViewModel matAssignVM)
        {
            try
            {
                SupportTruckMaterial supportTruckMaterial = new SupportTruckMaterial()
                {
                    MaterialId = matAssignVM.MaterialId,
                    VehicleId = matAssignVM.VehicleId,
                };

                await _supportTruckMaterialRepository.AddSupportTruckMaterial(supportTruckMaterial);

                await _materialService.UpdateMaterialAssigned(supportTruckMaterial.MaterialId, true);

                await _uow.Commit();

                return supportTruckMaterial.Id;
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to add support truck material (Service). Exception: " + e);
                throw;
            }
        }

        public async Task<SupportTruckMaterial> GetSupportTruckMaterial(MaterialAssignmentViewModel matAssignVM)
        {
            try
            {
                SupportTruckMaterial supportTruckMaterial = await _supportTruckMaterialRepository.GetSupportTruckMaterial(matAssignVM)
                    ?? throw new Exception("Failed to get support truck material (null)");

                await _uow.Commit();

                return supportTruckMaterial;
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to remove support truck material (Service). Exception: " + e);
                throw;
            }
        }

        public async Task RemoveSupportTruckMaterial(MaterialAssignmentViewModel matAssignVM)
        {
            try
            {
                SupportTruckMaterial supportTruckMaterial = await _supportTruckMaterialRepository.GetSupportTruckMaterial(matAssignVM) 
                    ?? throw new Exception("Failed to remove support truck material (null)");
                
                _supportTruckMaterialRepository.RemoveSupportTruckMaterial(supportTruckMaterial);

                await _materialService.UpdateMaterialAssigned(supportTruckMaterial.MaterialId, false);

                await _uow.Commit();
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to remove support truck material (Service). Exception: " + e);
                throw;
            }
        }
    }
}
