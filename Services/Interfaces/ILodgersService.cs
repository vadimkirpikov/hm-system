using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface ILodgersService: IBaseService<LodgerDto, Lodger, LodgerView>
{
    Task<IEnumerable<LodgerView>> GetOwnersOfFlatAsync(IEnumerable<int> flatIds);
    Task<IEnumerable<LodgerView>?> GetAllLodgersOrderedAsync(string fieldName, bool isDesc);
    
}