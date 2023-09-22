using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FacultyEvaluationSystem.Infrastructure;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<T> CreateAsync(T entity)
    {
        EntityEntry<T> entry = await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<T> RetrieveAll()
    {
        return _dbContext.Set<T>().AsQueryable();
    }

    public IQueryable<T> RetrieveAllByCondition(Expression<Func<T, bool>> condition)
    {
        return _dbContext.Set<T>().Where(condition).AsQueryable();
    }

    public async Task<T?> RetrieveAsync(Guid id)
    {
        var keyValues = new object[] { id };
        return await _dbContext.Set<T>().FindAsync(keyValues);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
