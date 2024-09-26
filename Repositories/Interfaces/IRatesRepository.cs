using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;

namespace HousingManagementService.Repositories.Interfaces;

public interface IRatesRepository: IBaseRepository<Rate, RateView>
{
    Task<IEnumerable<Rate>> GetAllRatesOfDepartmentAsync(IEnumerable<int> departmentIds);
    Task<IEnumerable<Rate>> GetAllRatesOfHouseAsync(IEnumerable<int> houseIds);
}