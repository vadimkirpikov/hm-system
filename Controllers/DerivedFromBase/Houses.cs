using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("houses")]
public class HousesController(IBaseService<HouseDto, HouseView> housesService)
    : BaseController<HouseDto, HouseView>(housesService);