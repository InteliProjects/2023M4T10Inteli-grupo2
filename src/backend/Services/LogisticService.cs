using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Repositories.Interfaces;
using BackendECOTVOS.Services.Interfaces;
using Microsoft.CodeAnalysis.Editing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Services
{
    public class LogisticService : ILogisticService
    {
        private readonly ILogisticRepository _logisticsRepository;
        private readonly IUnitOfWork _uow;

        public LogisticService(ILogisticRepository logisticsRepository, IUnitOfWork uow)
        {
            _logisticsRepository = logisticsRepository;
            _uow = uow;
        }

        public async Task<int> AddLogistic(LogisticViewModel log)
        {
            try
            {
                Logistic logistic = new Logistic()
                {
                    OperatorId = log.OperatorId,
                    VehicleId = log.VehicleId,
                    Front = log.Front,
                    Date = DateOnly.FromDateTime(DateTime.Now)
                };

                await _logisticsRepository.AddLogistic(logistic);

                await _uow.Commit();

                return logistic.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add logistic (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Logistic>> GetAllLogistics()
        {
            try
            {
                IEnumerable<Logistic> logs = await _logisticsRepository.GetAllLogistics() ??
                   throw new Exception("Failed to get all logistics (null).");

                return logs;
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to get all logistics (Service). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<Logistic> GetLogisticByOperatorId(int operatorId)
        {
            try
            {
                Logistic log = await _logisticsRepository.GetLogisticByOperatorId(operatorId) ??
                   throw new Exception("Failed to get logistic by operator id (null).");

                return log;
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed to get logistic by operator id (Service). Exception: " + e.Message);
                throw;
            }
        }
    }
}
