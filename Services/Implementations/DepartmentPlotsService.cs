using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class DepartmentPlotsService(IBaseRepository<DepartmentPlot, DepartmentPlotView> repository, IMapper mapper) : BaseService<DepartmentPlotDto, DepartmentPlot,DepartmentPlotView>(repository, mapper), IDepartmentPlotsService
{
    public async Task<IEnumerable<DepartmentPlotView>?> GetAllDepartmentPlotsOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<DepartmentPlotView, object>>? orderByFunction = fieldName switch
        {
            "plot" => p => p.PlotId,
            "department" => p => p.DepartmentId,
            _ => null
        };
        return await GetAllOrderedByAsync(orderByFunction, isDesc);
    }
}