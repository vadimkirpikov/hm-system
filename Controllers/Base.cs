using HousingManagementService.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

public class BaseController<TDto, TView>(IBaseService<TDto, TView> baseBaseService) : ControllerBase
    where TDto : class where TView : class
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] TDto model)
    {
        await baseBaseService.AddAsync(model);
        return Ok();
    }
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TDto modelDto)
    {
        var result = await baseBaseService.UpdateAsync(id, modelDto);
        if (result) return Ok();
        return NotFound();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await baseBaseService.DeleteByIdAsync(id);
        if (result) return Ok();
        return NotFound();
    }

    [HttpGet("read")]
    public async Task<IActionResult> GetAllAsync([FromQuery] string? filter = null, [FromQuery] string? orderBy = null)
    {
        var result = await baseBaseService.GetAllAsync(filter, orderBy);
        return Ok(result);
    }
    
}