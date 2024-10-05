namespace HousingManagementService.Repositories.Base.Abstractions;

public interface ICreateRepository<in T>
{
    Task<bool> AddAsync(T entity);
}