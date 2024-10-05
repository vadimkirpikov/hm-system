using HousingManagementService.Models.Dtos;
using HousingManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingManagementService.Controllers;

[ApiController]
[Route("house-and-flats")]
public class HouseAndFlatsController(IHouseAndFlatsService houseAndFlatsService): ControllerBase
{
    [HttpPost("insert")]
    public async Task<IActionResult> AddHouseWithFlatsAsync([FromBody] HouseWithFlatsDto houseWithFlatsDto)
    {
        await houseAndFlatsService.AddHouseWithFlatsAsync(houseWithFlatsDto.HouseDto, houseWithFlatsDto.FlatsDto);
        return Ok();
    }
}