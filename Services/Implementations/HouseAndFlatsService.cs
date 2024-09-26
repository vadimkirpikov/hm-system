using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class HouseAndFlatsService(IHouseAndFlatsRepository houseAndFlatsRepository, IMapper mapper): IHouseAndFlatsService
{
    public async Task<bool> AddHouseWithFlatsAsync(HouseDto houseDto, IEnumerable<FlatDto> flatDtos)
    {
        try
        {
            var house = mapper.Map<House>(houseDto);
            var flats = mapper.Map<IEnumerable<Flat>>(flatDtos);
            await houseAndFlatsRepository.AddHouseWithFlatsAsync(house, flats.ToList());
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}