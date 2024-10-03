namespace HousingManagementService.Repositories.Base.Abstractions;

public interface IDeleteRepository<in T>
{
    Task DeleteAsync(T entity);
}