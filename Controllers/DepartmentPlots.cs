using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/department-plots")]
public class DepartmentPlotsController(
    IDepartmentPlotsService departmentPlotsService)
    : BaseController<DepartmentPlotDto, DepartmentPlot, DepartmentPlotView>(departmentPlotsService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<IActionResult> GetDepartmentPlotsByOrder(string order, bool desc)
    {
        var departmentPlots = await departmentPlotsService.GetAllDepartmentPlotsOrderedAsync(order, desc);
        if (departmentPlots is null) return NotFound();
        return Ok(departmentPlots);
    }
}
