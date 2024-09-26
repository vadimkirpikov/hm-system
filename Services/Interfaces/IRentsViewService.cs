using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;

namespace HousingManagementService.Services.Interfaces;

public interface IRentsViewService
{
    Task<IEnumerable<RentView>?> GetRentsAsync(RentViewFilterDto filter);
}