using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers.DerivedFromBase;

[ApiController]
[Route("department")]
public class DepartmentsController(IBaseService<DepartmentDto, DepartmentView> departmentsService) : BaseController<DepartmentDto, DepartmentView>(departmentsService);