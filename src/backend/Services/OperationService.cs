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
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationsRepository;
        private readonly ILogisticService _logisticsService;
        private readonly IOperationMaterialsService _operationMaterialsService;
        private readonly IUnitOfWork _uow;
        
        public OperationService(IOperationRepository operationsRepository, ILogisticService logisticsService,
            IOperationMaterialsService operationMaterialsService, IUnitOfWork uow)
        {
            _operationsRepository = operationsRepository;
            _logisticsService = logisticsService;
            _operationMaterialsService = operationMaterialsService;
            _uow = uow;
        }

        public async Task<int> AddOperation(OperationViewModel opVM)
        {
            try
            {
                Logistic reqLogistic = await _logisticsService.GetLogisticByOperatorId(opVM.RequesterOperatorId);
                Logistic respLogistic = await _logisticsService.GetLogisticByOperatorId(opVM.ResponsibleOperatorId);

                Operation op = new()
                {
                    RequesterLogisticId = reqLogistic.OperatorId,
                    ResponsibleLogisticId = respLogistic.OperatorId,
                    Type = opVM.Type,
                    BeginHour = DateTime.Now,
                    EstimatedDuration = opVM.EstimatedDuration,
                    Status = 'A'
                };

                await _operationsRepository.AddOperation(op);

                await _uow.Commit();

                await _operationMaterialsService.AddOperationMaterial(op.Id, opVM.AssociatedMaterialsIds);

                return op.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add operation (Service). Exception: " + e.Message);
                throw;
            };
        }

        public async Task<IEnumerable<OperationDTO>> GetAllOperations()
        {
            try
            {
                IEnumerable<OperationMaterialsDTO> opMatsDTOs = _operationMaterialsService
                    .GetAssociatedMaterialsDescriptionsByOperationIds(await _operationsRepository.GetAllOperationsIds());

                IEnumerable<OperationDTO> ops = await _operationsRepository.GetAllOperations() ??
                    throw new Exception("Failed to get all operations (null).");
                
                foreach(var op in ops)
                {
                    op.AssociatedMaterialsDescriptions = opMatsDTOs.First(i => i.OperationId == op.Id).MaterialsDescriptions;
                }

                return ops;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all operations (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<OperationDTO>> GetFinishedOperations()
        {
            try
            {
                IEnumerable<OperationMaterialsDTO> opMatsDTOs = _operationMaterialsService
                    .GetAssociatedMaterialsDescriptionsByOperationIds(await _operationsRepository.GetAllOperationsIdsByStatus('F'));

                IEnumerable<OperationDTO> ops = await _operationsRepository.GetOperationsByStatus('F') ??
                    throw new Exception("Failed to get finished operations (null).");

                foreach (var op in ops)
                {
                    op.AssociatedMaterialsDescriptions = opMatsDTOs.First(i => i.OperationId == op.Id).MaterialsDescriptions;
                }

                return ops;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get finished operations (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<OperationDTO>> GetLostOperations()
        {
            try
            {
                IEnumerable<OperationMaterialsDTO> opMatsDTOs = _operationMaterialsService
                    .GetAssociatedMaterialsDescriptionsByOperationIds(await _operationsRepository.GetAllOperationsIdsByStatus('L'));

                IEnumerable<OperationDTO> ops = await _operationsRepository.GetOperationsByStatus('L') ??
                    throw new Exception("Failed to get lost operations (null).");

                foreach (var op in ops)
                {
                    op.AssociatedMaterialsDescriptions = opMatsDTOs.First(i => i.OperationId == op.Id).MaterialsDescriptions;
                }

                return ops;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get lost operations (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<OperationDTO>> GetActiveOperations()
        {
            try
            {
                IEnumerable<OperationMaterialsDTO> opMatsDTOs = _operationMaterialsService
                    .GetAssociatedMaterialsDescriptionsByOperationIds(await _operationsRepository.GetAllOperationsIdsByStatus('A'));

                IEnumerable<OperationDTO> ops = await _operationsRepository.GetOperationsByStatus('A') ??
                    throw new Exception("Failed to get active operations (null).");

                foreach (var op in ops)
                {
                    op.AssociatedMaterialsDescriptions = opMatsDTOs.First(i => i.OperationId == op.Id).MaterialsDescriptions;
                }

                return ops;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get active operations (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<Operation> GetOperationById(int id)
        {
            try
            {
                return await _operationsRepository.GetOperationById(id) ??
                    throw new Exception("Failed to get operation by id (null).");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get operation by id (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task UpdateOperationStatus(int id, char status)
        {
            try
            {
                Operation op = await GetOperationById(id) ??
                    throw new Exception("Failed to get operation by id (null).");

                _operationsRepository.UpdateOperationStatus(op, status);

                await _uow.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to update operation (Service). Exception: " + e.Message);
                throw;
            };

        }
    }
}
