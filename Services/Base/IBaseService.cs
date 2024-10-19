using System.Linq.Expressions;

namespace HousingManagementService.Services.Base;

public interface IBaseService<in TDto, TView> where TDto : class where TView : class
{
    Task<bool> AddAsync(TDto modelDto);
    Task<bool> DeleteByIdAsync(int id);
    Task<bool> UpdateAsync(int id, TDto modelDto);
    Task<IEnumerable<TView>> GetAllAsync(string? filter, string? orderBy);
}