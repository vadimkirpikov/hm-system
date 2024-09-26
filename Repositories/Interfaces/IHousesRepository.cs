using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;

namespace HousingManagementService.Repositories.Interfaces;

public interface IHousesRepository: IBaseRepository<House, HouseView>
{
    Task<IEnumerable<House>> GetHousesFromPlotAsync(IEnumerable<int> plotIds);
}