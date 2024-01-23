using BackendECOTVOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendECOTVOS.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<Operator> Operators { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Logistic> Logistics { get; set; }
        public DbSet<MaterialAssignment> Material_Assignments { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<SupportTruckMaterial> Support_Truck_Materials { get; set; }
        public DbSet<OperationMaterials> Operation_Materials { get; set; }
    }
}
