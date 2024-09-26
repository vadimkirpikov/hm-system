using System.Linq.Expressions;
using HousingManagementService.Models.Views;

namespace HousingManagementService.Repositories.Interfaces;

public interface ISuitabilityOfPlotsRepository
{
    Task<IEnumerable<SuitabilityOfPlot>> GetSuitabilityOfPlotsAsync(IEnumerable<int> plotIds,
        IEnumerable<int> priorityLevels, int minBudget, int maxBudget,
        Expression<Func<SuitabilityOfPlot, object>>? orderBy, bool isDesc);
}