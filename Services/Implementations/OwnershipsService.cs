using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class OwnershipsService(IBaseRepository<Ownership, OwnershipView> ownershipsRepository, IMapper mapper): BaseService<OwnershipDto, Ownership, OwnershipView>(ownershipsRepository, mapper), IOwnershipsService
{
    public async Task<IEnumerable<OwnershipView>?> GetAllOwnershipsOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<OwnershipView, object>>? orderByFunction = fieldName switch
        {
            "flat" => os => os.FlatId,
            "lodger" => os => os.LodgerId,
            "area" => os => os.OwnedArea,
            _ => null
        };
        return await GetAllOrderedByAsync(orderByFunction, isDesc);
    }
}