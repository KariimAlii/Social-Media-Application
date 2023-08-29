using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Entities;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepository<User> _UserRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
