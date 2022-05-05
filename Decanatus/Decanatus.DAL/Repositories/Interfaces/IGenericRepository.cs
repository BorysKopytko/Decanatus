using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> Includer(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null/*, Expression<Func<T, T>> selector = null*/);

    }
}
