using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Decanatus.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        //Task<IEnumerable<T>> Includer(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<IEnumerable<T>> GetData(Expression<Func<T, bool>>? filter = null,
                                                       Expression<Func<T, T>>? selector = null,
                                                       Func<IQueryable<T>, IQueryable<T>>? sorting = null,
                                                       Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    }
}
