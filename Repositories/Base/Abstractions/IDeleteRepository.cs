namespace HousingManagementService.Repositories.Base.Abstractions;

public interface IDeleteRepository<in T>
{
    Task<bool> DeleteAsync(T entity);
}