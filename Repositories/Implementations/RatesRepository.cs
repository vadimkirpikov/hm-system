using HousingManagementService.Data;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class RatesRepository(HousingManagementDbContext context) : BaseRepository<Rate, RateView>(context), IRatesRepository
{
    public async Task<IEnumerable<Rate>> GetAllRatesOfDepartmentAsync(IEnumerable<int> departmentIds)
    {
        return await Context.Rates
            .Where(rate => departmentIds.Contains(rate.DepartmentId))
            .ToListAsync();
    }

    public async Task<IEnumerable<Rate>> GetAllRatesOfHouseAsync(IEnumerable<int> houseIds)
    {
        return await Context.Rates
            .Where(rate => houseIds.Contains(rate.HouseId))
            .ToListAsync();
    }
}