using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Films.Repository.Common
{
    public interface IGenericRepository<T, TKey> where T : class, new()
    {
        IQueryable<T> GetAll();
        Task<T> GetAsync(TKey id);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        Task AddAsync(T obj);
        void Update(T obj);
        Task DeleteAsync(TKey key);

        Task SaveAsync();
    }
}
