using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;

namespace HousingManagementService.Repositories.Interfaces;

public interface IDepartmentsRepository: IBaseRepository<Department, DepartmentView>
{
    Task<IEnumerable<Department>> GetDepartmentsOfServiceAsync(IEnumerable<int> serviceIds);
    Task<IEnumerable<Department>> GetDepartmentsOfPlotAsync(IEnumerable<int> plotIds);
}