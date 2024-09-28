using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Filters;
using HousingManagementService.Models.Views;

namespace HousingManagementService.Services.Interfaces;

public interface IDepartmentsRevenueService
{
    Task<IEnumerable<DepartmentRevenue>> GetDepartmentsRevenueAsync(DepartmentsRevenueFilterDto departmentsRevenueFilterDto);
}