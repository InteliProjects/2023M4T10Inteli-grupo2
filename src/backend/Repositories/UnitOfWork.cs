using BackendECOTVOS.Data.Context;
using BackendECOTVOS.Repositories.Interfaces;
using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {

        }

    }
}
