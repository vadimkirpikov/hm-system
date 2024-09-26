using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IFlatsService: IBaseService<FlatDto, Flat, FlatView>
{
    Task AddFlatsToHouseAsync(List<FlatDto> flats);
    Task<IEnumerable<FlatView>> GetAllFlatsOfHouseAsync(IEnumerable<int> houseId);
    Task<IEnumerable<FlatView>> GetAllFlatsOfOwner(IEnumerable<int> lodgerId);
    Task<IEnumerable<FlatView>?> GetAllFlatsOrderedAsync(string fieldName, bool isDesc);
}