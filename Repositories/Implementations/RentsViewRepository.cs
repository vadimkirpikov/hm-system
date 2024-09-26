using System.Linq.Expressions;
using HousingManagementService.Data;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class RentsViewRepository(HousingManagementDbContext context) : IRentsViewRepository
{
    public async Task<IEnumerable<RentView>> GetRentViewsAsync(IEnumerable<string> addresses, int minRent, int maxRent,
        Expression<Func<RentView, object>>? orderBy, bool isDesc)
    {
        var query = context.RentsView
            .Where(rv => addresses.Any(addr => rv.HouseAddress.Equals(addr)))
            .Where(rv => rv.Rent >= minRent && rv.Rent <= maxRent)
            .AsQueryable();
        if (orderBy is null)
        {
            return await query.ToListAsync();
        }
        query = isDesc ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        return await query.ToListAsync();
    }
}