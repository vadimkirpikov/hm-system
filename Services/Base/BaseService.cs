using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Repositories.Base;

namespace HousingManagementService.Services.Base;

public class BaseService<TDto, T, TView>(IBaseRepository<T, TView> repository, IMapper mapper)
    : IBaseService<TDto,T, TView> where TDto : class where TView : class where T : class
{
    protected readonly IMapper Mapper = mapper;
    public async Task AddAsync(TDto modelDto)
    {
        await repository.AddAsync(Mapper.Map<T>(modelDto));
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var model = await repository.GetByIdAsync(id);
        if (model is null) return false;
        await repository.DeleteAsync(model);
        return true;
    }

    public async Task<bool> UpdateAsync(int id, TDto modelDto)
    {
        var model = await repository.GetByIdAsync(id);
        if (model is null) return false;
        Mapper.Map(modelDto, model);
        await repository.UpdateAsync(model);
        return true;
    }

    public async Task<IEnumerable<TView>> GetAllAsync()
    {
        var modelViews = await repository.GetAllAsync();
        return modelViews;
    }

    public async Task<IEnumerable<TView>?> GetAllOrderedByAsync<TKey>(Expression<Func<TView, TKey>>? predicate, bool isDesc)
    {
        if (predicate is null) return null;
        var modelViews = await repository.GetAllAsyncOrderBy(predicate, isDesc);
        return modelViews;
    }
}