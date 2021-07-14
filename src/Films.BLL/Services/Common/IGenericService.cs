using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Films.BLL.Services.Common
{
    public interface IGenericService<T, TKey>
       where T : class
    {
        // Read.
        IQueryable<T> GetAll();
        Task<T> GetAsync(TKey key);

        // Create.
        Task<T> AddAsync(T item);

        // Update.
        Task<T> UpdateAsync(T item);

        // Delete.
        Task DeleteAsync(TKey id);

        // Filter.
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }
}
