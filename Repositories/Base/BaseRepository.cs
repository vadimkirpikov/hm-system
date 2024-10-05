using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using HousingManagementService.Data;
using HousingManagementService.Repositories.Base.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Base;

public class BaseRepository<T, TView>(HousingManagementDbContext context)
    : ICrudRepository<T, TView>
    where T : class where TView : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    private readonly DbSet<TView> _dbSetView = context.Set<TView>();

    public async Task<bool> AddAsync(T entity)
    {
        try
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<TView>> GetAllFilteredAsync(string? filter = null, string? sortBy = null)
    {
        var query = _dbSetView.AsQueryable();
        if (!string.IsNullOrEmpty(filter))
            query = query.Where(filter);
        if (!string.IsNullOrEmpty(sortBy))
            query = query.OrderBy(sortBy);
        return await query.ToListAsync();
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }

    }
}