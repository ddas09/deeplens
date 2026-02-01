using System.Linq.Expressions;
using DeepLens.DAL.Interfaces;
using DeepLens.Data;
using Microsoft.EntityFrameworkCore;

namespace DeepLens.DAL.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly DeepLensDBContext _context;
    protected readonly DbSet<TEntity> _entities;

    protected BaseRepository(DeepLensDBContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }
    
    // CREATE
    public async Task AddAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _entities.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }
    
    // READ
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.FirstOrDefaultAsync(predicate);
    }

    public async Task<IReadOnlyList<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> query = _entities;

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync();
    }
    
    // UPDATE
    public async Task UpdateAsync(TEntity entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        _entities.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }
    
    // DELETE
    public async Task DeleteAsync(TEntity entity)
    {
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        _entities.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}