using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services
{
    public class OperatorService : IOperatorService
    {
        private readonly IOperatorRepository _operatorsRepository;
        private readonly IUnitOfWork _uow;

        public OperatorService(IOperatorRepository operatorsRepository, IUnitOfWork uow)
        {
            _operatorsRepository = operatorsRepository;
            _uow = uow;
        }

        public async Task<int> AddOperator(OperatorViewModel opv)
        {
            try
            {
                Operator op = new Operator
                {
                    Name = opv.Name,
                    Role = opv.Role,
                };

                await _operatorsRepository.AddOperator(op);

                await _uow.Commit();

                return op.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add operator (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<OperatorDTO>> GetAllOperators()
        {
            try
            {
                IEnumerable<OperatorDTO> operators = await _operatorsRepository.GetAllOperators() ??
                    throw new Exception("Failed to get all operators (null).");

                return operators;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all operators (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<OperatorDTO> GetOperatorById(int id)
        {
            try
            {
                Operator operatorResult = await _operatorsRepository.GetOperatorById(id) ??
                    throw new Exception("Failed to get operator by id (null).");

                OperatorDTO opDTO = new OperatorDTO()
                {
                    Id = operatorResult.Id,
                    Name = operatorResult.Name,
                    Role = operatorResult.Role
                };

                return opDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get operator by id (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<OperatorDTO> GetOperatorByName(string name)
        {
            try
            {
                OperatorDTO operatorResult = await _operatorsRepository.GetOperatorByName(name) ??
                    throw new Exception("Failed to get operator by id (null).");

                return operatorResult;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get operator by name (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task UpdateOperator(OperatorDTO op)
        {
            try
            {
                Operator opToChange = await _operatorsRepository.GetOperatorById(op.Id) ??
                    throw new Exception("Failed to get operator by id (null).");

                Operator opNewData = new Operator()
                {
                    Id = opToChange.Id,
                    Name = op.Name,
                    Role = op.Role
                };

                _operatorsRepository.UpdateOperator(opToChange, opNewData);

                await _uow.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to update operator (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task DeleteOperator(int id)
        {
            try
            {
                _operatorsRepository.DeleteOperator(id);

                await _uow.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to delete operator (Service). Exception: " + e.Message);
                throw;
            }
        }
    }
}
