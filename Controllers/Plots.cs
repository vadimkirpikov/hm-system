using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/plots")]
public class PlotsController(IPlotsService plotsService) : BaseController<PlotDto, Plot, PlotView>(plotsService)
{
    [HttpPost("from-departments")]
    public async Task<IActionResult> GetPlotsOfDepartmentAsync([FromBody] IEnumerable<int> ids)
    {
        var plots = await plotsService.GetPlotsOfDepartmentAsync(ids);
        return Ok(plots);
    }
}