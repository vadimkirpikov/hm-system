using System.Linq.Expressions;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class DepartmentsRevenueService(IDepartmentsRevenueRepository departmentsRevenueRepository)
    : IDepartmentsRevenueService
{
    public async Task<IEnumerable<DepartmentRevenue>> GetDepartmentsRevenueAsync(
        DepartmentsRevenueFilterDto departmentsRevenueFilterDto)
    {
        Expression<Func<DepartmentRevenue, object>>? orderBy = departmentsRevenueFilterDto.OrderByFieldName switch
        {
            "department-name" => dr => dr.DepartmentName,
            "service-name" => dr => dr.ServiceName,
            "flats-count" => dr => dr.FlatsCount,
            "revenue" => dr => dr.Revenue,
            _ => null
        };
        return await departmentsRevenueRepository.GetDepartmentsRevenueAsync(departmentsRevenueFilterDto.DepartmentIds,
            departmentsRevenueFilterDto.DepartmentIds, departmentsRevenueFilterDto.MinFlatsCount,
            departmentsRevenueFilterDto.MaxFlatsCount, departmentsRevenueFilterDto.MinRevenue,
            departmentsRevenueFilterDto.MaxRevenue, orderBy, departmentsRevenueFilterDto.IsDesc);
    }
}