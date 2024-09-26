using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/houses")]
public class HousesController(IHousesService houseService) : BaseController<HouseDto,House, HouseView>(houseService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<IActionResult> GetHousesOrderedBy(string order, bool desc)
    {
        var houses = await houseService.GetAllHousesOrderedAsync(order, desc);
        if (houses is null) return NotFound();
        return Ok(houses);
        
    }
    
    [HttpPost("from-plots")]
    public async Task<IActionResult> GetHousesFromPlot([FromBody] IEnumerable<int> ids)
    {
        var houses = await houseService.GetHousesOfPlotAsync(ids);
        return Ok(houses);
    }
    
    
}