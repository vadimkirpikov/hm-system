using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("lodgers")]
public class LodgersController(IBaseService<LodgerDto, LodgerView> lodgersService) : BaseController<LodgerDto, LodgerView>(lodgersService);