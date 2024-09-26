using HousingManagementService.Models.Dtos;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("api/house-and-flats")]
public class HouseAndFlatsController(IHouseAndFlatsService houseAndFlatsService) : ControllerBase
{
    [HttpPost("add-house-with-flats")]
    public async Task<IActionResult> AddHouseWithFlatsAsync([FromBody] HouseWithFlatsDto houseWithFlatsDto)
    {
        var result = await houseAndFlatsService.AddHouseWithFlatsAsync(houseWithFlatsDto.HouseDto, houseWithFlatsDto.FlatsDto);
        if (result) return Ok();
        return NotFound();
    }
}