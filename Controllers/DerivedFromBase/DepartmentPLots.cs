using HousingManagementService.Controllers.Base;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("department-plots")]
public class DepartmentPLotsController(IBaseService<DepartmentPlotDto, DepartmentPlotView> departmentPlotsService) :
    BaseController<DepartmentPlotDto, DepartmentPlotView>(departmentPlotsService);