using EFCore.BulkExtensions;
using HousingManagementService.Data;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class FlatsRepository(HousingManagementDbContext context) : BaseRepository<Flat, FlatView>(context), IFlatsRepository
{
    public async Task AddFlatsToHouseAsync(List<Flat> flats)
    {
        await Context.BulkInsertAsync(flats);
        await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Flat>> GetFlatsOfHouseAsync(IEnumerable<int> houseIds)
    {
        return await Context.Flats
            .Where(flat => houseIds.Contains(flat.HouseId))
            .ToListAsync();
    }

    public async Task<IEnumerable<Flat>> GetFlatsOfLodgerAsync(IEnumerable<int> lodgerIds)
    {
        return await Context.Ownerships
            .Where(ownership => lodgerIds.Contains(ownership.Id))
            .Select(ownership => ownership.Flat)
            .ToListAsync();
    }
}