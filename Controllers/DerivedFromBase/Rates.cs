using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("rates")]
public class RatesController(IBaseService<RateDto, RateView> ratesService) : BaseController<RateDto, RateView>(ratesService)
{

}