using System.Linq.Expressions;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Filters;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class RentsViewService(IRentsViewRepository rentsViewRepository) : IRentsViewService
{
    public async Task<IEnumerable<RentView>?> GetRentsAsync(RentViewFilterDto filter)
    {
        Expression<Func<RentView, object>>? filterExpression = filter.OrderByFieldName switch
        {
            "house-address" => rv => rv.HouseAddress,
            "rent" => rv => rv.Rent,
            _ => null
        };
        return await rentsViewRepository.GetRentViewsAsync(filter.Addresses, filter.MinPrice, filter.MaxPrice,
            filterExpression, filter.IsDescending);
    }
}