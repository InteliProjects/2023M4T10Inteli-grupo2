using BackendECOTVOS.Data.Context;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories
{
    public class LogisticRepository : ILogisticRepository
    {
        private readonly ApplicationDbContext _context;

        public LogisticRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLogistic(Logistic logistic)
        {
            try
            {
                await _context.Logistics.AddAsync(logistic);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get logistic by operator id (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Logistic>> GetAllLogistics()
        {
            try
            {
                return await _context.Logistics.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all logistics (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<Logistic> GetLogisticByOperatorId(int operatorId)
        {
            try
            {
                DateOnly date = DateOnly.Parse(DateOnly.FromDateTime(DateTime.Now).ToString("yyyy/MM/dd"));

                return await _context.Logistics.FirstOrDefaultAsync(i => 
                    i.OperatorId == operatorId && i.Date == date);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get logistic by operator id (Repository). Exception: " + e.Message);
                throw;
            }
        }
    }
}
