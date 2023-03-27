using System.Linq.Expressions;
using Domain.Common;

namespace Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseAuditableEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null!,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
                                           string include = null!,
                                           bool disableTracking = true);
        Task<IReadOnlyList<T>> GetPagination(Expression<Func<T, bool>> predicate = null!,
                                             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
                                             List<Expression<Func<T, object>>> includes = null!,
                                             string include = null!,
                                             bool disableTracking = true);
        Task<T> GetById(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}