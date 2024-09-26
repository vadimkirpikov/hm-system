using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class HousesService(IHousesRepository housesRepository, IMapper mapper)
    : BaseService<HouseDto, House, HouseView>(housesRepository, mapper), IHousesService
{
    public async Task<IEnumerable<HouseView>> GetHousesOfPlotAsync(IEnumerable<int> plotIds)
    {
        var houses = await housesRepository.GetHousesFromPlotAsync(plotIds);
        var housesView = Mapper.Map<IEnumerable<HouseView>>(houses);
        return housesView;
    }

    public async Task<IEnumerable<HouseView>?> GetAllHousesOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<HouseView, object>>? orderByFunction = fieldName switch
        {
            "plot" => h => h.PlotId,
            _ => null
        };
        return await GetAllOrderedByAsync(orderByFunction, isDesc);
    }
}