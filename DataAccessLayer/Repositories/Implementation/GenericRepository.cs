using DataAccessLayer.Data;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            var entitiesList = entities.ToList();
            await _context.Set<T>().AddRangeAsync(entitiesList);
            return entities;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public Task<int> CountAsyncWhere(Expression<Func<T, bool>> Filter)
        {
            return _context.Set<T>().CountAsync(Filter);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
       => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);

        }
        public async Task<IEnumerable<T>> GetListWith(Expression<Func<T, bool>>? Filter = null, string[]? Includes = null)
        {

            IQueryable<T> query = _context.Set<T>();
            if (Filter != null)
            {
                query = query.Where(Filter);
            }

            if (Includes != null)
            {
                foreach (var item in Includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();


        }

        public async Task<T> GetFirstOrDefaultWith(Expression<Func<T, bool>> Filter = null, string[] Includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (Filter != null)
            {
                query = query.Where(Filter);
            }

            if (Includes != null)
            {
                foreach (var item in Includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;

        }
    }
}
