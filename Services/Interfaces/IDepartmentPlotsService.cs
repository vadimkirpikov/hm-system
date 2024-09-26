using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IDepartmentPlotsService: IBaseService<DepartmentPlotDto, DepartmentPlot, DepartmentPlotView>
{
    Task<IEnumerable<DepartmentPlotView>?> GetAllDepartmentPlotsOrderedAsync(string fieldName, bool isDesc);
}