using System.Linq.Dynamic.Core;
using HousingManagementService.Data;
using HousingManagementService.Repositories.Base.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Implementions;

public class ReadRepository<TView>(HousingManagementDbContext context) : IReadRepository<TView> where TView : class
{
    
    protected readonly DbSet<TView> DbSetView = context.Set<TView>();
    protected readonly HousingManagementDbContext Context = context;
    public async Task<IEnumerable<TView>> GetAllFilteredAsync(string? filter = null, string? sortBy = null)
    {
        var query = DbSetView.AsQueryable();
        if (!string.IsNullOrEmpty(filter))
            query = query.Where(filter);
        if (!string.IsNullOrEmpty(sortBy))
            query = query.OrderBy(sortBy);
        return await query.ToListAsync();
    }
}