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
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _uow;

        public MaterialService(IMaterialRepository materialRepository, IUnitOfWork uow)
        {
            _materialRepository = materialRepository;
            _uow = uow;
        }

        public async Task<int> AddMaterial(MaterialViewModel material)
        {
            try
            {
                Material newMaterial = new Material()
                {
                    Description = material.Description,
                    Branch = material.Branch,
                    Assigned = false
                };

                await _materialRepository.AddMaterial(newMaterial);

                await _uow.Commit();

                return newMaterial.Id;
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to add material (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllUnassignedMaterials()
        {
            try
            {
                IEnumerable<Material> materials = await _materialRepository.GetAllUnassignedMaterials() ??
                    throw new Exception("Failed to get all unassigned materials (null).");

                List<MaterialDTO> materialsDTO = materials.Select(i => new MaterialDTO()
                {
                    Id = i.Id,
                    Description = i.Description,
                    Branch = i.Branch
                }).ToList();

                return materialsDTO;
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to get all unassigned materials (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<Material> GetMaterialById(int id)
        {
            try
            {
                Material material = await _materialRepository.GetMaterialById(id) ??
                    throw new Exception("Failed to get material by id (null).");

                return material;
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Failed to get material by id (Service). Exception: " + e.Message);
                throw;
            }
        }

        public IEnumerable<OperationMaterialsDTO> GetOperationMaterialsDTODescriptions(IEnumerable<OperationMaterialsDTO> opMatsDTO)
        {
            try
            {
                foreach(var opMat in opMatsDTO)
                {
                    opMat.MaterialsDescriptions = _materialRepository.GetMaterialsDescriptionsByIds(opMat.MaterialsIds);
                }

                return opMatsDTO;
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to update material assigned (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task UpdateMaterialAssigned(int id, bool assigned)
        {
            try
            {
                Material material = await GetMaterialById(id) ??
                    throw new Exception("Failed to get material by id (null).");
                
                _materialRepository.UpdateMaterialAssigned(material, assigned);
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to update material assigned (Service). Exception: " + e.Message);
                throw;
            }
        }
    }
}
