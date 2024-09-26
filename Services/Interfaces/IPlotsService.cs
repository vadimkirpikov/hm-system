using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IPlotsService: IBaseService<PlotDto,Plot, PlotView>
{
    Task<IEnumerable<PlotView>> GetPlotsOfDepartmentAsync(IEnumerable<int> departmentIds);
}