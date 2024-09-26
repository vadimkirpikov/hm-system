using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IRatesService: IBaseService<RateDto, Rate, RateView>
{
    Task<IEnumerable<RateView>> GetAllRatesOfHouseAsync(IEnumerable<int> houseId);
    Task<IEnumerable<RateView>> GetAllRatesOfDepartmentAsync(IEnumerable<int> departmentIds);
    Task<IEnumerable<RateView>?> GetAllRatesOrderedAsync(string fieldName, bool isDesc);
}