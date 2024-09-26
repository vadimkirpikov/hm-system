using System.Linq.Expressions;

namespace HousingManagementService.Services.Base;

public interface IBaseService<in TDto,T, TView> where TDto : class where TView : class
{
    Task AddAsync(TDto modelDto);
    Task<bool> DeleteByIdAsync(int id);
    Task<bool> UpdateAsync(int id, TDto modelDto);
    Task<IEnumerable<TView>> GetAllAsync();
    Task<IEnumerable<TView>?> GetAllOrderedByAsync<TKey>(Expression<Func<TView, TKey>> predicate, bool isDesc);
}