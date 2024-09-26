using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;

namespace HousingManagementService.Repositories.Interfaces;

public interface ILodgersRepository: IBaseRepository<Lodger, LodgerView>
{
    Task<IEnumerable<Lodger>> GetOwnersOfFlatAsync(IEnumerable<int> flatIds);
}