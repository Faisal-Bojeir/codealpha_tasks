using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using Event_Registration_System.Domain.Interfaces;
using Restaurant_Management_System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Implementation.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> GetByConditionAsync(
            Expression<Func<T, bool>> condition,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();

            query = query.IncludesEntities(includes);

            return await query.FirstOrDefaultAsync(condition, cancellationToken);
        }


        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public async Task<PagedList<T>> GetRangeByConditionAsync(Expression<Func<T, bool>> condition, QueryStringParameters parameters, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();

            query = query.IncludesEntities(includes);

            query = query.Where(condition);

            query = query.AsNoTracking();

            return await query.ToPagedList(parameters);
        }

        public async Task<PagedList<TResult>> GetRangeByConditionAsync<TKey, TResult>(
            Expression<Func<T, bool>> condition,
            QueryStringParameters parameters,
            Expression<Func<T, TKey>> groupBy,
            Expression<Func<IGrouping<TKey, T>, TResult>> selector,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includes) where TResult : class
        {
            IQueryable<T> query = _context.Set<T>();

            query = query.IncludesEntities(includes);

            query = query.Where(condition);

            query = query.AsNoTracking();

            var groupedQuery = query.GroupBy(groupBy).Select(selector);

            return await groupedQuery.ToPagedList(parameters);
        }


        public async Task<IEnumerable<T>> GetRangeByConditionAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();

            query = query.IncludesEntities(includes);

            query = query.Where(condition);

            query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<PagedList<TResult>> GetRangeByConditionAsync<TResult>(
            Expression<Func<T, bool>> condition,
            Expression<Func<T, TResult>> selector,
            QueryStringParameters parameters,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includes)
            where TResult : class
        {
            IQueryable<T> query = _context.Set<T>();

            query = query.IncludesEntities(includes);

            query = query.Where(condition);

            query = query.AsNoTracking();

            var projected = query.Select(selector);

            return await projected.ToPagedList(parameters);
        }


        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
