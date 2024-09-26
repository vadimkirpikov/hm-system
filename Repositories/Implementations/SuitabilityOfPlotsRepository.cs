using System.Linq.Expressions;
using HousingManagementService.Data;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementations;

public class SuitabilityOfPlotsRepository(HousingManagementDbContext context): ISuitabilityOfPlotsRepository
{
    public async Task<IEnumerable<SuitabilityOfPlot>> GetSuitabilityOfPlotsAsync(IEnumerable<int> plotIds, IEnumerable<int> priorityLevels, int minBudget, int maxBudget,
        Expression<Func<SuitabilityOfPlot, object>>? orderBy, bool isDesc)
    {
        var query = context.SuitabilityOfPlots
            .Where(sp => plotIds.Contains(sp.PlotId)
            && priorityLevels.Contains(sp.PriorityLevel)
            && sp.Budget >= minBudget
            && sp.Budget <= maxBudget)
            .AsQueryable();
        if (orderBy is null)
        {
            return await query.ToListAsync();
        }
        query = isDesc ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        return await query.ToListAsync();
    }
}