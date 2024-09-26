using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class RatesService(IRatesRepository ratesRepository, IMapper mapper)
    : BaseService<RateDto, Rate, RateView>(ratesRepository, mapper), IRatesService
{
    public async Task<IEnumerable<RateView>> GetAllRatesOfHouseAsync(IEnumerable<int> houseIds)
    {
        var rates = await ratesRepository.GetAllRatesOfHouseAsync(houseIds);
        var ratesView = Mapper.Map<IEnumerable<RateView>>(rates);
        return ratesView;
    }

    public async Task<IEnumerable<RateView>> GetAllRatesOfDepartmentAsync(IEnumerable<int> departmentIds)
    {
        var rates = await ratesRepository.GetAllRatesOfDepartmentAsync(departmentIds);
        var ratesView = Mapper.Map<IEnumerable<RateView>>(rates);
        return ratesView;
    }

    public async Task<IEnumerable<RateView>?> GetAllRatesOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<RateView, object>>? orderByFunction = fieldName switch
        {
            "department" => r => r.DepartmentId,
            "house" => r => r.HouseId,
            "cost" => r => r.ConstantPricePerMonth,
            "cost-pu" => r => r.PricePerUnit,
            "cost-per-meter" => r => r.PricePerSquareMeter,
            _ => null
        };
        return await GetAllOrderedByAsync(orderByFunction, isDesc);
    }
}