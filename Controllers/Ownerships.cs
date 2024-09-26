using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/ownerships")]
public class OwnershipsController(IOwnershipsService ownershipsService)
    : BaseController<OwnershipDto, Ownership, OwnershipView>(ownershipsService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<IActionResult> GetOrderedOwnerships([FromRoute] string order, [FromRoute] bool desc)
    {
        var ownerShips = await ownershipsService.GetAllOwnershipsOrderedAsync(order, desc);
        return Ok(ownerShips);
    }
}