using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IOwnershipsService: IBaseService<OwnershipDto, Ownership, OwnershipView>
{
    Task<IEnumerable<OwnershipView>?> GetAllOwnershipsOrderedAsync(string fieldName, bool isDesc);
}