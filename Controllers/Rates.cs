using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/rates")]
public class RatesController(IRatesService ratesService) : BaseController<RateDto, Rate, RateView>(ratesService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<IActionResult> GetOrderedRatesAsync([FromRoute] string order, [FromRoute] bool desc)
    {
        var rates = await ratesService.GetAllRatesOrderedAsync(order, desc);
        if (rates is null) return NotFound();
        return Ok(rates);
    }
    
    [HttpPost("from-houses")]
    public async Task<IActionResult> GetHouseRatesAsync([FromBody] IEnumerable<int> ids)
    {
        var rates = await ratesService.GetAllRatesOfHouseAsync(ids);
        return Ok(rates);
    }
    [HttpPost("from-departments")]
    public async Task<IActionResult> GetDepartmentsRatesAsync([FromBody] IEnumerable<int> ids)
    {
        var rates = await ratesService.GetAllRatesOfDepartmentAsync(ids);
        return Ok(rates);
    }
}