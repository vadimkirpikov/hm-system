using System.Linq.Expressions;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;

namespace HousingManagementService.Repositories.Interfaces;

public interface IRentsViewRepository
{
    Task<IEnumerable<RentView>> GetRentViewsAsync(IEnumerable<string> addresses, int minValue, int maxValue,
        Expression<Func<RentView, object>>? orderBy, bool isDesc);
}