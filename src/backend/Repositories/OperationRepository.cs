using BackendECOTVOS.Data.Context;
using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly ApplicationDbContext _context;

        public OperationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOperation(Operation op)
        {
            try
            {
                await _context.Operations.AddAsync(op);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add operation (Repository). Exception: " + e.Message);
                throw;
            };
        }

        public async Task<IEnumerable<OperationDTO>> GetAllOperations()
        {
            try
            {
                List<OperationDTO> ops = await (from op in _context.Operations
                                                join lreq in _context.Logistics on op.RequesterLogisticId equals lreq.Id
                                                join lresp in _context.Logistics on op.ResponsibleLogisticId equals lresp.Id
                                                join req in _context.Operators on lreq.OperatorId equals req.Id
                                                join resp in _context.Operators on lresp.OperatorId equals resp.Id
                                                join reqv in _context.Vehicles on lreq.VehicleId equals reqv.Id
                                                join respv in _context.Vehicles on lresp.VehicleId equals respv.Id
                                                select new OperationDTO
                                                {
                                                    Id = op.Id,
                                                    Type = op.Type == 'M' ? "Manutenção" : "Transporte",
                                                    Status = op.Status == 'F' ? "Finalizada"
                                                    : op.Status == 'A' ? "Ativa" : "Perdida",

                                                    BeginHour = op.BeginHour,
                                                    EstimatedDuration = op.EstimatedDuration,
                                                    Duration = op.Duration,
                                                    RequesterOperatorName = req.Name,
                                                    RequesterOperatorFunction = req.Role,
                                                    ResponsibleOperatorName = resp.Name,
                                                    ResponsibleOperatorFunction = resp.Role,
                                                    RequesterVehicleDescription = reqv.Description,
                                                    ResponsibleVehicleDescription = respv.Description,
                                                }).ToListAsync();


                return ops;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all operations (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<OperationDTO>> GetOperationsByStatus(char status)
        {
            try
            {
                List<OperationDTO> ops = await (from op in _context.Operations
                                                join lreq in _context.Logistics on op.RequesterLogisticId equals lreq.Id
                                                join lresp in _context.Logistics on op.ResponsibleLogisticId equals lresp.Id
                                                join req in _context.Operators on lreq.OperatorId equals req.Id
                                                join resp in _context.Operators on lresp.OperatorId equals resp.Id
                                                join reqv in _context.Vehicles on lreq.VehicleId equals reqv.Id
                                                join respv in _context.Vehicles on lresp.VehicleId equals respv.Id
                                                where op.Status == status
                                                select new OperationDTO
                                                {
                                                    Id = op.Id,
                                                    Type = op.Type == 'M' ? "Manutenção" : "Transporte",
                                                    Status = op.Status == 'F' ? "Finalizada"
                                                    : op.Status == 'A' ? "Ativa" : "Perdida",

                                                    BeginHour = op.BeginHour,
                                                    EstimatedDuration = op.EstimatedDuration,
                                                    Duration = op.Duration,
                                                    RequesterOperatorName = req.Name,
                                                    RequesterOperatorFunction = req.Role,
                                                    ResponsibleOperatorName = resp.Name,
                                                    ResponsibleOperatorFunction = resp.Role,
                                                    RequesterVehicleDescription = reqv.Description,
                                                    ResponsibleVehicleDescription = respv.Description,
                                                }).ToListAsync();

                return ops;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get operations by status (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<Operation> GetOperationById(int id)
        {
            try
            {
                return await _context.Operations.FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get operation by id (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public void UpdateOperationStatus(Operation op, char status)
        {
            try
            {
                Operation newOp = op;
                newOp.Status = status;

                if (status == 'F')
                {
                    newOp.Duration = new TimeOnly((DateTime.Now - newOp.BeginHour).Ticks);
                }

                _context.Operations.Entry(op).CurrentValues.SetValues(newOp);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to update operation (Repository). Exception: " + e.Message);
                throw;
            };
        }

        public async Task<List<int>> GetAllOperationsIds()
        {
            try
            {
                return await _context.Operations.Select(i => i.Id).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all operations ids (Repository). Exception: " + e.Message);
                throw;
            };
        }

        public async Task<List<int>> GetAllOperationsIdsByStatus(char status)
        {
            try
            {
                return await _context.Operations.Where(o => o.Status == status).Select(i => i.Id).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all operations ids by status (Repository). Exception: " + e.Message);
                throw;
            };
        }
    }
}
