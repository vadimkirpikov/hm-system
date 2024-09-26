using HousingManagementService.Data;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class HousesRepository(HousingManagementDbContext context) : BaseRepository<House, HouseView>(context), IHousesRepository
{
    public async Task<IEnumerable<House>> GetHousesFromPlotAsync(IEnumerable<int> plotIds)
    {
        return await Context.Houses
            .Where(house => plotIds.Contains(house.PlotId))
            .ToListAsync();
    }
}