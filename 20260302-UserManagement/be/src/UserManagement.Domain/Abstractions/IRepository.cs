using System.Linq.Expressions;

namespace UserManagement.Domain.Abstractions;

public interface IRepository<T>
{
    public Task<(IEnumerable<TResult> Data, int TotalCount)> GetAllAsync<TResult>(int? pageSize, int? pageNumber,
                                                                                       Expression<Func<T, TResult>> selectQuery,
                                                                                       Expression<Func<T, bool>>? predicate = null,
                                                                                       (Expression<Func<T, object>> OrderBy, bool IsDescending)[]? orderByExpressions = null,
                                                                                       CancellationToken token = default,
                                                                                       params Expression<Func<T, object>>[] navigationProperties);

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null,
                                        CancellationToken token = default,
                                        params Expression<Func<T, object>>[] navigationProperties);

    public Task<TResult?> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>>? predicate = null,
                                    Expression<Func<T, TResult>> selectQuery = null!,
                                    CancellationToken token = default,
                                    params Expression<Func<T, object>>[] navigationProperties);

    public Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties);

    public Task AddRangeAsync(IEnumerable<T> listEntity);                    
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public void DeleteRange(IEnumerable<T> listEntity);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    public Task BeginTransactionAsync();
    public Task CommitAsync();
    public Task RollbackAsync();
}
