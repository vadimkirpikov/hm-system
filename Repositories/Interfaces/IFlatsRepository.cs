using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;

namespace HousingManagementService.Repositories.Interfaces;

public interface IFlatsRepository: IBaseRepository<Flat, FlatView>
{
    Task AddFlatsToHouseAsync(List<Flat> flats);
    Task<IEnumerable<Flat>> GetFlatsOfHouseAsync(IEnumerable<int> houseIds);
    Task<IEnumerable<Flat>> GetFlatsOfLodgerAsync(IEnumerable<int> lodgerIds);
}