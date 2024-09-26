using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IDepartmentsService: IBaseService<DepartmentDto,Department, DepartmentView>
{
    Task<IEnumerable<DepartmentView>> GetDepartmentsOfServiceAsync(IEnumerable<int> serviceIds);
    Task<IEnumerable<DepartmentView>> GetDepartmentsOfPlotAsync(IEnumerable<int> plotIds);
    Task<IEnumerable<DepartmentView>?> GetAllDepartmentsOrderedAsync(string fieldName, bool isDesc);
}