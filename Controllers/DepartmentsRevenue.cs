using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Filters;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/departments-revenue")]
public class DepartmentsRevenueController(IDepartmentsRevenueService departmentsRevenueService) : ControllerBase
{
    [HttpPost("read-filtered")]
    public async Task<IActionResult> GetFilteredDepartmentsRevenueAsync(
        [FromBody] DepartmentsRevenueFilterDto departmentsRevenueFilterDto)
    {
        var departmentsRevenue = await departmentsRevenueService.GetDepartmentsRevenueAsync(departmentsRevenueFilterDto);
        return Ok(departmentsRevenue);
    }
}