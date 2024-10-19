using HousingManagementService.Repositories.Base.Abstractions;
using HousingManagementService.Services.Interfaces;

namespace HousingManagementService.Services.Implementations;

public class ReadReportService<TView>(IReadRepository<TView> readRepository): IReadReportService<TView>
{
    public async Task<IEnumerable<TView>> ReadAsync(string? filter = null, string? orderBy = null)
    {
        return await readRepository.GetAllFilteredAsync(filter, orderBy);
    }
}
