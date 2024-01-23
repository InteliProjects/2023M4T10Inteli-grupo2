using System.Threading.Tasks;

namespace BackendECOTVOS.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public Task Commit();
        public void Rollback();
    }
}
