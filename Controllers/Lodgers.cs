using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/lodgers")]
public class LodgersController(ILodgersService lodgersService) : BaseController<LodgerDto, Lodger, LodgerView>(lodgersService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<IActionResult> GetLodgersOrderedBy([FromRoute] string order, [FromRoute] bool desc)
    {
        var lodgers = await lodgersService.GetAllLodgersOrderedAsync(order, desc);
        if (lodgers is null) return NotFound();
        return Ok(lodgers);
    }
    
    [HttpPost("from-flats")]
    public async Task<IActionResult> GetOwnersOfFlatAsync([FromBody] IEnumerable<int> ids)
    {
        var lodgers = await lodgersService.GetOwnersOfFlatAsync(ids);
        return Ok(lodgers);
    }
    
}