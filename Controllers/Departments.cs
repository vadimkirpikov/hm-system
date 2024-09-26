using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/departments")]
public class DepartmentsController(IDepartmentsService departmentService) : BaseController<DepartmentDto, Department, DepartmentView>(departmentService)
{
    [HttpGet("order-by/{order}/{desc:bool}")]
    public async Task<IActionResult> GetAllDepartmentsOrderedByAsync([FromRoute] string order, [FromRoute] bool desc)
    {
        var departments = await departmentService.GetAllDepartmentsOrderedAsync(order, desc);
        if (departments is null) return NotFound();
        return Ok(departments);
    }
    [HttpPost("from-services")]
    public async Task<ActionResult> GetDepartmentsOfServiceAsync([FromBody] IEnumerable<int> ids)
    {
        var departments = await departmentService.GetDepartmentsOfServiceAsync(ids);
        return Ok(departments);
    }

    [HttpPost("from-plots")]
    public async Task<ActionResult> GetDepartmentsOfPlotAsync([FromBody] IEnumerable<int> ids)
    {
        var departments = await departmentService.GetDepartmentsOfPlotAsync(ids);
        return Ok(departments);
    }
    

}