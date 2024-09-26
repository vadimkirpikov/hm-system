using HousingManagementService.Models.Dtos;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/suitable-of-plots")]
public class SuitableOfPlotsController(ISuitabilityOfPlotsService suitabilityOfPlotsService) : ControllerBase
{
    [HttpPost("read-filtered")]
    public async Task<IActionResult> GetSuitableOfPlotsAsync(
        [FromBody] SuitabilityOfPlotFilterDto suitabilityOfPlotFilterDto)
    {
        var suitabilityOfPlots = await suitabilityOfPlotsService.GetSuitabilityOfPlotsAsync(suitabilityOfPlotFilterDto);
        return Ok(suitabilityOfPlots);
    }
}