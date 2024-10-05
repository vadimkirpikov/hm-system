using HousingManagementService.Models.Dtos;
using HousingManagementService.Repositories.Base.Abstractions;

namespace HousingManagementService.Services.Interfaces;

public interface IHouseAndFlatsService
{
    Task AddHouseWithFlatsAsync(HouseDto houseDto, IEnumerable<FlatDto> flatDtos);
}