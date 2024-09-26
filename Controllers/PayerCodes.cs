using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/payer-codes")]
public class PayerCodesController(IPayerCodesService payerCodesService)
    : BaseController<PayerCodeDto, PayerCode, PayerCodeView>(payerCodesService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<IActionResult> GetOrderedPayerCodes([FromRoute] string order, [FromRoute] bool desc)
    {
        var payerCodes = await payerCodesService.GetAllPayerCodesOrderedAsync(order, desc);
        if (payerCodes is null) return NotFound();
        return Ok(payerCodes);
    }
}
