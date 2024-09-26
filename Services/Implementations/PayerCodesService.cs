using System.Linq.Expressions;
using AutoMapper;
using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Repositories.Base;
using HousingManagementService.Services.Base;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class PayerCodesService(IBaseRepository<PayerCode, PayerCodeView> repository, IMapper mapper) : BaseService<PayerCodeDto, PayerCode, PayerCodeView>(repository, mapper), IPayerCodesService
{
    public async Task<IEnumerable<PayerCodeView>?> GetAllPayerCodesOrderedAsync(string fieldName, bool isDesc)
    {
        Expression<Func<PayerCodeView, object>>? orderByFunction = fieldName switch
        {
            "duty" => pc => pc.Duty,
            "lodger" => pc => pc.LodgerId,
            "fee-percent" => pc => pc.FeePercent,
            _ => null
        };
        return await GetAllOrderedByAsync(orderByFunction, isDesc);
    }
}