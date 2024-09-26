using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;

namespace HousingManagementService.Repositories.Interfaces;

public interface IPlotsRepository: IBaseRepository<Plot, PlotView>
{
    Task<IEnumerable<Plot>> GetAllPlotOfDepartmentAsync(IEnumerable<int> departmentIds);
}