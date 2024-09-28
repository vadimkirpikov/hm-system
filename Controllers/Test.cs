using HousingManagementService.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("test")]
public class TestController(HousingManagementDbContext context) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Test([FromQuery] string filter)
    {
        var query = context.Flats.AsQueryable();
        
        query = query.Where(filter);
        var res = await query.ToListAsync();
        return Ok(res);
    }
}