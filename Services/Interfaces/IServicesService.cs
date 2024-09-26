using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IServicesService: IBaseService<ServiceDto, Service, ServiceView>
{
    Task<IEnumerable<ServiceView>?> GetAllServicesOrderedAsync(string fieldName, bool isDesc);
}