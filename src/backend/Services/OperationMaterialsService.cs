using BackendECOTVOS.Services.Interfaces;
using BackendECOTVOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using System.Linq;

namespace BackendECOTVOS.Services
{
    public class OperationMaterialsService : IOperationMaterialsService
    {
        private readonly IOperationMaterialsRepository _operationMaterialsRepository;
        private readonly IMaterialService _materialService;
        private readonly IUnitOfWork _uow;

        public OperationMaterialsService(IOperationMaterialsRepository operationMaterialsRepository,
            IMaterialService materialService, IUnitOfWork uow)
        {
            _operationMaterialsRepository = operationMaterialsRepository;
            _materialService = materialService;
            _uow = uow;
        }

        public async Task AddOperationMaterial(int operationId, List<int> materialIds)
        {
            try
            {
                await _operationMaterialsRepository.AddOperationMaterial(operationId, materialIds);
                await _uow.Commit();
            }

            catch (Exception e)  
            {
                Console.WriteLine("Failed to add operation material (Service). Exception: " + e.Message);
                throw;
            }
        }

        public IEnumerable<OperationMaterialsDTO> GetAssociatedMaterialsDescriptionsByOperationIds(List<int> operationIds)
        {
            try
            {
                IEnumerable<OperationMaterials> opMats =  _operationMaterialsRepository.GetOperationMaterialsByOperationIds(operationIds);

                List<OperationMaterialsDTO> opMatsDTO = opMats.GroupBy(opMat => opMat.Id).Select(i => new OperationMaterialsDTO()
                {
                    OperationId = i.Key,
                    MaterialsIds = i.Select(o => o.AssociatedMaterialId).ToList(),
                }).ToList();

                return _materialService.GetOperationMaterialsDTODescriptions(opMatsDTO);
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to get associated materials description by operation ids (Service). Exception: " + e.Message);
                throw;
            }
        }
    }
}
