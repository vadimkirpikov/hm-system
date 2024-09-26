using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Implementations;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class LodgersService(ILodgersRepository lodgersRepository, IMapper mapper)
    : BaseService<LodgerDto, Lodger, LodgerView>(lodgersRepository, mapper), ILodgersService
{
    public async Task<IEnumerable<LodgerView>> GetOwnersOfFlatAsync(IEnumerable<int> flatIds)
    {
        var lodgers = await lodgersRepository.GetOwnersOfFlatAsync(flatIds);
        var lodgersView = Mapper.Map<IEnumerable<LodgerView>>(lodgers);
        return lodgersView;
    }

    public async Task<IEnumerable<LodgerView>?> GetAllLodgersOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<LodgerView, object>>? orderByFunction = fieldName switch
        {
            "first-name" => l => l.FirstName,
            "middle-name" => l => l.MiddleName,
            "last-name" => l => l.LastName,
            "passport" => l => l.LodgerPassport,
            "age" => l => l.Age,
            _ => null
        };
        return await GetAllOrderedByAsync(orderByFunction, isDesc);
    }
}