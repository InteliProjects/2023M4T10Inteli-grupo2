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
    public class OperatorRepository : IOperatorRepository
    {
        private readonly ApplicationDbContext _context;

        public OperatorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OperatorDTO>> GetAllOperators()
        {
            try
            {
                IEnumerable<OperatorDTO> operators = await _context.Operators
                    .Select(o => new OperatorDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Role = o.Role,
                    })
                    .ToListAsync();

                return operators;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get all operators (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<Operator> GetOperatorById(int id)
        {
            try
            {
                Operator? op = await _context.Operators.FirstOrDefaultAsync(i => i.Id == id);

                return op;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get operator by id (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task<OperatorDTO> GetOperatorByName(string name)
        {
            try
            {
                OperatorDTO? operators = await _context.Operators
                    .Where(o => o.Name == name)
                    .Select(o => new OperatorDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Role = o.Role,
                    })
                    .FirstOrDefaultAsync();

                return operators;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get operator by name (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public async Task AddOperator(Operator op)
        {
            try
            {
                await _context.Operators.AddAsync(op);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add operator (Repository). Exception: " + e.Message);
                throw;
            };
        }

        public void UpdateOperator(Operator op, Operator opNewData)
        {
            try
            {
                _context.Operators.Entry(op).CurrentValues.SetValues(opNewData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to update operator (Repository). Exception: " + e.Message);
                throw;
            }
        }

        public void DeleteOperator(int id)
        {
            try
            {
                var operatorToDelete = _context.Operators.Find(id);

                if (operatorToDelete != null)
                {
                    _context.Operators.Remove(operatorToDelete);
                }
                else
                {
                    throw new Exception("Operator not found for deletion.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to delete operator (Repository). Exception: " + e.Message);
                throw;
            }
        }
    }
}

        
      
