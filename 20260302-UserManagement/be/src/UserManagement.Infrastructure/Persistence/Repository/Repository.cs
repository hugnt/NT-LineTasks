using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UserManagement.Application.Abstractions.Persistence;

namespace UserManagement.Infrastructure.Persistence.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected IDbContextTransaction? _transaction;
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<(IEnumerable<TResult> Data, int TotalCount)> GetAllAsync<TResult>(int? pageSize, int? pageNumber,
                                                                                                Expression<Func<T, TResult>> selectQuery,
                                                                                                Expression<Func<T, bool>>? predicate = null,
                                                                                                (Expression<Func<T, object>> OrderBy, bool IsDescending)[]? orderByExpressions = null,
                                                                                                CancellationToken token = default,
                                                                                                params Expression<Func<T, object>>[] navigationProperties)
    {
        var query = GetQuery(predicate, navigationProperties);
        var totalCount = await query.CountAsync(token);

        if (orderByExpressions != null && orderByExpressions.Any())
        {
            IOrderedQueryable<T>? orderedQuery = null;
            for (int i = 0; i < orderByExpressions.Length; i++)
            {
                var orderByExpression = orderByExpressions[i];
                var orderBy = orderByExpression.OrderBy;
                var isDescending = orderByExpression.IsDescending;

                if (i == 0)
                {
                    orderedQuery = isDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
                }
                else
                {
                    orderedQuery = isDescending ? orderedQuery!.ThenByDescending(orderBy) : orderedQuery!.ThenBy(orderBy);
                }

            }
            query = orderedQuery!;
        }

        IQueryable<TResult> projectedQuery = query.Select(selectQuery);

        if (pageSize.HasValue && pageNumber.HasValue)
        {
            projectedQuery = projectedQuery.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
        }

        //var queryString = projectedQuery.ToQueryString();
        return (await projectedQuery.ToListAsync(token), totalCount);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }


    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

    }

    protected IQueryable<T> GetQuery(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] navigationProperties)
    {
        IQueryable<T> dbQuery = _context.Set<T>().AsNoTracking();
        if (predicate != null)
        {
            dbQuery = dbQuery.Where(predicate);
        }
        return navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties)
    {
        return await GetQuery(predicate, navigationProperties).FirstOrDefaultAsync(token);
    }


    public async Task<TResult?> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, TResult>> selectQuery = null!, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties)
    {
        if (selectQuery == null) throw new ArgumentNullException(nameof(selectQuery));
        var query = GetQuery(predicate, navigationProperties);
        return await query.Select(selectQuery).FirstOrDefaultAsync(token);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken token = default, params Expression<Func<T, object>>[] navigationProperties)
    {
        return await GetQuery(predicate, navigationProperties).AnyAsync(token);
    }


    public void DeleteRange(IEnumerable<T> listEntity)
    {
        _context.Set<T>().RemoveRange(listEntity);
    }

    public Task AddRangeAsync(IEnumerable<T> listEntity)
    {
        return _context.Set<T>().AddRangeAsync(listEntity);
    }
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

}