using EFCore.BulkExtensions;
using HousingManagementService.Data;
using HousingManagementService.Repositories.Base.Abstractions;

namespace HousingManagementService.Repositories.Base;

public class BulkInsertRepository<T>(HousingManagementDbContext context): IBulkInsertRepository<T> where T: class
{
    public async Task BulkInsertAsync(IEnumerable<T> entities)
    {
        await context.BulkInsertAsync(entities);
    }
}