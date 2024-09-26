using HousingManagementService.Data;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class DepartmentsRepository(HousingManagementDbContext context) : BaseRepository<Department, DepartmentView>(context), IDepartmentsRepository
{
    public async Task<IEnumerable<Department>> GetDepartmentsOfServiceAsync(IEnumerable<int> serviceIds)
    {
        return await Context.Departments
            .Where(department => serviceIds.Contains(department.ServiceId))
            .ToListAsync();
    }

    public async Task<IEnumerable<Department>> GetDepartmentsOfPlotAsync(IEnumerable<int> plotIds)
    {
        return await Context.DepartmentPlots
            .Where(departmentPlot => plotIds.Contains(departmentPlot.Id))
            .Select(departmentPlot => departmentPlot.Department)
            .ToListAsync();
    }
}