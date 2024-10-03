namespace HousingManagementService.Repositories.Base.Abstractions;

public interface ICreateRepository<in T>
{
    Task AddAsync(T entity);
}