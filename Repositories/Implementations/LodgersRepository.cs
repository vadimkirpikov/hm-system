using HousingManagementService.Data;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class LodgersRepository(HousingManagementDbContext context) : BaseRepository<Lodger, LodgerView>(context), ILodgersRepository
{
    public async Task<IEnumerable<Lodger>> GetOwnersOfFlatAsync(IEnumerable<int> flatIds)
    {
        return await Context.Ownerships
            .Where(ownerShip => flatIds.Contains(ownerShip.Id))
            .Select(ownerShip => ownerShip.Lodger)
            .ToListAsync();
    }
}