using System.Linq.Expressions;
using HousingManagementService.Data;
using Microsoft.EntityFrameworkCore;

namespace HousingManagementService.Repositories.Base;

public class BaseRepository<T, TView>(HousingManagementDbContext context) : IBaseRepository<T, TView> where T: class where TView : class
{
    protected readonly HousingManagementDbContext Context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();
    private readonly DbSet<TView> _dbSetView = context.Set<TView>();
    public async Task AddAsync(T entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task<IEnumerable<TView>> GetAllAsync()
    {
        return await _dbSetView.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T? entity)
    {
        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<TView>> GetAllAsyncOrderBy<TKey>(Expression<Func<TView, TKey>> orderBy, bool isDesc = false)
    {
        if (isDesc)
        {
            return await _dbSetView.OrderByDescending(orderBy).ToListAsync();
        }
        return await _dbSetView.OrderBy(orderBy).ToListAsync();
    }
}