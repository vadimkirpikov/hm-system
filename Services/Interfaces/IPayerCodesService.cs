using HousingManagementService.Models.Domain;
using HousingManagementService.Models.Dtos;
using HousingManagementService.Models.Views;
using HousingManagementService.Services.Base;

namespace HousingManagementService.Services.Interfaces;

public interface IPayerCodesService: IBaseService<PayerCodeDto, PayerCode,PayerCodeView>
{
    Task<IEnumerable<PayerCodeView>?> GetAllPayerCodesOrderedAsync(string fieldName, bool isDesc);
}