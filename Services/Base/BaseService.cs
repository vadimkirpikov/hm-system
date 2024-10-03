using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Base.Abstractions;

namespace HousingManagementService.Services.Base;

public class BaseService<TDto, T, TView>(ICrudRepository<T, TView> repository, IMapper mapper)
    : IBaseService<TDto, TView> where TDto : class where TView : class where T : class
{
    protected readonly IMapper Mapper = mapper;
    protected readonly ICrudRepository<T, TView> Repository = repository;
    public async Task AddAsync(TDto modelDto)
    {
        await Repository.AddAsync(Mapper.Map<T>(modelDto));
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var model = await Repository.GetByIdAsync(id);
        if (model is null) return false;
        await Repository.DeleteAsync(model);
        return true;
    }

    public async Task<bool> UpdateAsync(int id, TDto modelDto)
    {
        var model = await Repository.GetByIdAsync(id);
        if (model is null) return false;
        Mapper.Map(modelDto, model);
        await Repository.UpdateAsync(model);
        return true;
    }
    public async Task<IEnumerable<TView>> GetAllAsync(string? filter=null, string? orderBy=null)
    {
        return await Repository.GetAllFilteredAsync(filter, orderBy);
    }
}