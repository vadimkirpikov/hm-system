using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.Base;

public class BaseReportsController<TView>(IReadReportService<TView> readReportService) : ControllerBase
{
    [HttpGet("read")]
    public async Task<IActionResult> GetAllAsync([FromQuery] string? filter = null, [FromQuery] string? orderBy = null)
    {
        var result = await readReportService.ReadAsync(filter, orderBy);
        return Ok(result);
    }
}