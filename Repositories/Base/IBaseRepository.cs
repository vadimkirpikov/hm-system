using System.Linq.Expressions;

namespace HousingManagementService.Repositories.Base;

public interface IBaseRepository<T, TView>
{
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<TView>> GetAllAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<TView>> GetAllAsyncOrderBy<TKey>(Expression<Func<TView, TKey>> orderBy, bool isDesc = false);
}