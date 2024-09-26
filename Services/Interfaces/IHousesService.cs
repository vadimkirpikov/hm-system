using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IHousesService: IBaseService<HouseDto,House, HouseView>
{
    Task<IEnumerable<HouseView>> GetHousesOfPlotAsync(IEnumerable<int> plotIds);
    Task<IEnumerable<HouseView>?> GetAllHousesOrderedAsync(string fieldName, bool isDesc);
}