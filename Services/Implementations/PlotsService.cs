using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class PlotsService(IPlotsRepository plotsRepository, IMapper mapper)
    : BaseService<PlotDto, Plot, PlotView>(plotsRepository, mapper), IPlotsService
{
    public async Task<IEnumerable<PlotView>> GetPlotsOfDepartmentAsync(IEnumerable<int> departmentIds)
    {
        var plots = await plotsRepository.GetAllPlotOfDepartmentAsync(departmentIds);
        var plotsView = Mapper.Map<IEnumerable<PlotView>>(plots);
        return plotsView;
    }
}