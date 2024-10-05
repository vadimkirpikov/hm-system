using HousingManagementService.Controllers;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("flats")]
public class FlatsController(IBaseService<FlatDto, FlatView> baseBaseService) : BaseController<FlatDto, FlatView>(baseBaseService);