using HousingManagementService.Models.Domain;

namespace HousingManagementService.Repositories.Interfaces;

public interface IHouseAndFlatsRepository
{
    Task AddHouseWithFlatsAsync(House house, List<Flat> flats);
}