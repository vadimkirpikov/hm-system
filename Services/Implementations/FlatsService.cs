using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class FlatsService(IFlatsRepository flatsRepository, IMapper mapper)
    : BaseService<FlatDto, Flat, FlatView>(flatsRepository, mapper), IFlatsService
{
    public async Task AddFlatsToHouseAsync(List<FlatDto> flatsDto)
    {
        await flatsRepository.AddFlatsToHouseAsync(Mapper.Map<IEnumerable<Flat>>(flatsDto).ToList());
    }

    public async Task<IEnumerable<FlatView>> GetAllFlatsOfHouseAsync(IEnumerable<int> houseId)
    {
        var flats = await flatsRepository.GetFlatsOfHouseAsync(houseId);
        var flatsView = Mapper.Map<IEnumerable<FlatView>>(flats);
        return flatsView;
    }

    public async Task<IEnumerable<FlatView>> GetAllFlatsOfOwner(IEnumerable<int> lodgerId)
    {
        var flats = await flatsRepository.GetFlatsOfLodgerAsync(lodgerId);
        var flatsView = Mapper.Map<IEnumerable<FlatView>>(flats);
        return flatsView;
    }

    public async Task<IEnumerable<FlatView>?> GetAllFlatsOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<FlatView, object>>? orderByFunction = fieldName switch
        {
            "house" => f => f.HouseId,
            "floor" => f => f.Floor,
            "number" => f => f.Number,
            "total-area" => f => f.TotalArea,
            _ => null
        };
        return await GetAllOrderedByAsync(orderByFunction, isDesc);
        
    }
}