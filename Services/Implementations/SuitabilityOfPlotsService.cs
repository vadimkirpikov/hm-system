using System.Linq.Expressions;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class SuitabilityOfPlotsService(ISuitabilityOfPlotsRepository suitabilityOfPlotsRepository)
    : ISuitabilityOfPlotsService
{
    public async Task<IEnumerable<SuitabilityOfPlot>> GetSuitabilityOfPlotsAsync(
        SuitabilityOfPlotFilterDto suitabilityOfPlotFilterDto)
    {
        Expression<Func<SuitabilityOfPlot, object>>? orderBy = suitabilityOfPlotFilterDto.OrderByFieldName switch
        {
            "priority-level" => sp => sp.PriorityLevel,
            "budget" => sp => sp.Budget,
            "remaining-services-count" => sp => sp.RemainingServicesCount,
            _ => null
        };
        return await suitabilityOfPlotsRepository.GetSuitabilityOfPlotsAsync(suitabilityOfPlotFilterDto.PlotIds,
            suitabilityOfPlotFilterDto.PriorityLevels, suitabilityOfPlotFilterDto.MinBudget,
            suitabilityOfPlotFilterDto.MaxBudget, orderBy, suitabilityOfPlotFilterDto.IsDesc);
    }
}