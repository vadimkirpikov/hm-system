using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/services")]
public class ServicesController(IServicesService servicesService)
    : BaseController<ServiceDto, Service, ServiceView>(servicesService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<ActionResult> GetOrderedServicesAsync([FromRoute] string order, [FromRoute] bool desc)
    {
        var services = await servicesService.GetAllServicesOrderedAsync(order, desc);
        if (services is null) return NotFound();
        return Ok(services);
    }
}