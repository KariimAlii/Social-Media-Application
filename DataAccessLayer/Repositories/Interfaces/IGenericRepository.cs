using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public T? GetById(int id);

        public Task<T> AddAsync(T entity);

        public T Update(T entity);

        public void Delete(T entity);

        public Task<IEnumerable<T>> GetListWith(Expression<Func<T, bool>>? Filter = null, string[]? Includes = null);
        public Task<T> GetFirstOrDefaultWith(Expression<Func<T, bool>> Filter = null, string[] Includes = null);

        public Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);

        public Task<int> CountAsync();

        public Task<int> CountAsyncWhere(Expression<Func<T, bool>> Filter);

    }
}
