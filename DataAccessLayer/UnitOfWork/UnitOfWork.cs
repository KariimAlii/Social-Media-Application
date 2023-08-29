using DataAccessLayer.Data;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IGenericRepository<User> _UserRepo { get; }
        public UnitOfWork(DataContext context , IGenericRepository<User> userRepo)
        {
            _context = context;
            _UserRepo = userRepo;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
