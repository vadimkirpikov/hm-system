namespace HousingManagementService.Repositories.Base.Abstractions;

public interface IUpdateRepository<T>
{
    Task<T?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(T entity);
}