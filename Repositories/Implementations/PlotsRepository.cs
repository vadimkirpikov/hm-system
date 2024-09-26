using HousingManagementService.Data;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class PlotsRepository(HousingManagementDbContext context) : BaseRepository<Plot, PlotView>(context), IPlotsRepository
{
    public async Task<IEnumerable<Plot>> GetAllPlotOfDepartmentAsync(IEnumerable<int> departmentIds)
    {
        return await Context.DepartmentPlots
            .Where(departmentPlot => departmentIds.Contains(departmentPlot.DepartmentId))
            .Select(departmentPlot => departmentPlot.Plot)
            .ToListAsync();
    }
}