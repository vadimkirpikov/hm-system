using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("ownerships")]
public class OwnershipsController(IBaseService<OwnershipDto, OwnershipView> ownershipsService)
    : BaseController<OwnershipDto, OwnershipView>(ownershipsService);