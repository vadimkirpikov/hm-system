using HousingManagementService.Models.Dtos;

namespace HousingManagementService.Services.Interfaces;

public interface IHouseAndFlatsService
{
    Task<bool> AddHouseWithFlatsAsync(HouseDto houseDto, IEnumerable<FlatDto> flatDtos);
}