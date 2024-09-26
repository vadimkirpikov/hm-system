using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/flats")]
public class FlatsController(IFlatsService flatsService) : BaseController<FlatDto,Flat, FlatView>(flatsService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<IActionResult> GetFlatsOrderedBy([FromRoute] string order, [FromRoute] bool desc)
    {
        var flats = await flatsService.GetAllFlatsOrderedAsync(order, desc);
        if (flats is null) return NotFound();
        return Ok(flats);
    }
    
    [HttpPost("from-houses")]
    public async Task<IActionResult> GetFlatsOfHouseAsync([FromBody] IEnumerable<int> ids)
    {
        var flats = await flatsService.GetAllFlatsOfHouseAsync(ids);
        return Ok(flats);
    }

    [HttpPost("from-owners")]
    public async Task<IActionResult> GetFlatsOfOwnerAsync([FromBody] IEnumerable<int> ids)
    {
        var flats = await flatsService.GetAllFlatsOfOwner(ids);
        return Ok(flats);
    }

    [HttpPost("add-flats-to-house")]
    public async Task<IActionResult> AddFlatsToHouseAsync([FromBody] List<FlatDto> flats)
    {
        await flatsService.AddFlatsToHouseAsync(flats);
        return Ok();
    }
}