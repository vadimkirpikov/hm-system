namespace HousingManagementService.Repositories.Base.Abstractions;

public interface IReadRepository<TView>
{
    Task<IEnumerable<TView>> GetAllFilteredAsync(string? filter = null, string? sortBy = null);
}