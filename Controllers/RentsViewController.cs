using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Filters;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/rents")]
public class RentsViewController(IRentsViewService rentsViewService) : ControllerBase
{
    [HttpPost("read-filtered")]
    public async Task<IActionResult> ReadFilteredRents([FromBody] RentViewFilterDto filter)
    {
        var rents = await rentsViewService.GetRentsAsync(filter);
        return Ok(rents);
    }
}