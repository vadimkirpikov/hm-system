namespace HousingManagementService.Repositories.Base.Abstractions;

public interface IBulkInsertRepository<in T>
{
    Task BulkInsertAsync(IEnumerable<T> entities);
}