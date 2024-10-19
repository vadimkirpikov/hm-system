using HousingManagementService.Controllers;
using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("plots")]
public class PlotsController(IBaseService<PlotDto, PlotView> plotsService) : BaseController<PlotDto, PlotView>(plotsService);