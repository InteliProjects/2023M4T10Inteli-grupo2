using BackendECOTVOS.Data.Context;
using BackendECOTVOS.Domain.Entities;
using BackendECOTVOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories
{
    public class OperationMaterialsRepository : IOperationMaterialsRepository
    {
        private readonly ApplicationDbContext _context;

        public OperationMaterialsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOperationMaterial(int operationId, List<int> materialIds)
        {
            try
            {
                if(materialIds.Count == 2)
                {
                    foreach (int materialId in materialIds)
                    {
                        OperationMaterials newOpMat = new OperationMaterials()
                        {
                            OperationId = operationId,
                            AssociatedMaterialId = materialId,
                            Defective = materialId == materialIds[0],
                        };
                        await _context.Operation_Materials.AddAsync(newOpMat);
                        return;
                    }
                }

                OperationMaterials opMat = new OperationMaterials()
                {
                    OperationId = operationId,
                    AssociatedMaterialId = materialIds[0],
                    Defective = false,
                };
                await _context.Operation_Materials.AddAsync(opMat);

            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add operation materials (Repository). Exception: " + e.Message);
            }
        }

        public IEnumerable<OperationMaterials> GetOperationMaterialsByOperationIds(List<int> operationIds)
        {
            try
            {
                return _context.Operation_Materials.AsEnumerable().Join(
                    operationIds, opMat => opMat.Id, id => id, (opMat, id) => opMat).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get operation materials by operation ids (Repository). Exception: " + e.Message);
                throw;
            }
        }
    }
}
