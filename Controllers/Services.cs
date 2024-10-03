using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("services")]
public class ServicesController(IBaseService<ServiceDto, ServiceView> baseService)
    : BaseController<ServiceDto, ServiceView>(baseService);
        
   