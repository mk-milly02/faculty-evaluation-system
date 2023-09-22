using System.Linq.Expressions;

namespace FacultyEvaluationSystem.Infrastructure;

public interface IRepository<T>
{
    Task DeleteAsync(T entity);
    Task<T> CreateAsync(T entity);
    Task<T?> RetrieveAsync(Guid id);
    Task UpdateAsync(T entity);
    IQueryable<T> RetrieveAll();
    IQueryable<T> RetrieveAllByCondition(Expression<Func<T, bool>> condition);
}
