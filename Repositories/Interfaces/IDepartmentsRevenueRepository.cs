using System.Linq.Expressions;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Views;

namespace HousingManagementService.Repositories.Interfaces;

public interface IDepartmentsRevenueRepository
{
    Task<IEnumerable<DepartmentRevenue>> GetDepartmentsRevenueAsync(IEnumerable<int> depIds, IEnumerable<int> servIds,
        int minFlatsCount, int maxFlatsCount, int minRevenue, int maxRevenue,
        Expression<Func<DepartmentRevenue, object>>? orderBy, bool isDesc);
}