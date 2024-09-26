using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class ServicesService(IBaseRepository<Service, ServiceView> repository, IMapper mapper) : BaseService<ServiceDto, Service, ServiceView>(repository, mapper), IServicesService
{
    public async Task<IEnumerable<ServiceView>?> GetAllServicesOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<ServiceView, object>>? orderByFunction = fieldName switch
        {
            "name" => s => s.Name,
            _ => null
        };
        return await GetAllOrderedByAsync(orderByFunction, isDesc);
    }
}