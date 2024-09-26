using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Interfaces;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class DepartmentsService(IDepartmentsRepository departmentsRepository, IMapper mapper)
    : BaseService<DepartmentDto, Department, DepartmentView>(departmentsRepository, mapper), IDepartmentsService
{

    public async Task<IEnumerable<DepartmentView>> GetDepartmentsOfServiceAsync(IEnumerable<int> serviceIds)
    {
        var departmentsView =
            Mapper.Map<IEnumerable<DepartmentView>>(
                await departmentsRepository.GetDepartmentsOfServiceAsync(serviceIds));
        return departmentsView;
    }

    public async Task<IEnumerable<DepartmentView>> GetDepartmentsOfPlotAsync(IEnumerable<int> plotIds)
    {
        var departmentsView =
            Mapper.Map<IEnumerable<DepartmentView>>(
                await departmentsRepository.GetDepartmentsOfPlotAsync(plotIds));
        return departmentsView;
    }

    public async Task<IEnumerable<DepartmentView>?> GetAllDepartmentsOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<DepartmentView, object>>? orderByFunction = fieldName switch
        {
            "name" => department => department.Name,
            "address" => department => department.Address,
            "service" => department => department.ServiceId,
            _ => null
        };
        var departmentsView = await GetAllOrderedByAsync(orderByFunction, isDesc);
        return departmentsView;
    }
}