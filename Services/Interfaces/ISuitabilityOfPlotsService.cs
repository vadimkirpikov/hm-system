using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;

namespace HousingManagementService.Services.Interfaces;

public interface ISuitabilityOfPlotsService
{
    Task<IEnumerable<SuitabilityOfPlot>> GetSuitabilityOfPlotsAsync(SuitabilityOfPlotFilterDto suitabilityOfPlotFilterDto);
}