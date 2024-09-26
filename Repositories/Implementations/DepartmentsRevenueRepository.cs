using System.Linq.Expressions;
using HousingManagementService.Data;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class DepartmentsRevenueRepository(HousingManagementDbContext context) : IDepartmentsRevenueRepository
{
    public async Task<IEnumerable<DepartmentRevenue>> GetDepartmentsRevenueAsync(IEnumerable<int> depIds,
        IEnumerable<int> servIds, int minFlatsCount, int maxFlatsCount, int minRevenue,
        int maxRevenue, Expression<Func<DepartmentRevenue, object>>? orderBy, bool isDesc)
    {
        var query = context.DepartmentsRevenue
            .Where(dr => servIds.Contains(dr.ServiceId)
                         && depIds.Contains(dr.DepartmentId)
                         && dr.FlatsCount >= minFlatsCount
                         && dr.FlatsCount <= maxFlatsCount
                         && dr.Revenue >= minRevenue
                         && dr.Revenue <= maxRevenue)
            .AsQueryable();
        if (orderBy is not null)
        {
            query = isDesc
                ? query.OrderByDescending(orderBy)
                : query.OrderBy(orderBy);
        }

        return await query.ToListAsync();
    }
}