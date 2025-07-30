using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using URL_Shortener.Core.Contract;
using URL_Shortener.EF.Data;
using URL_Shortener.EF.Interface;

namespace URL_Shortener.EF.Implementation.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, ISoftDelete
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(condition);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task<TEntity> GetRangeByConditionAsync(Expression<Func<TEntity, bool>> conditions, params Expression<Func<TEntity, object>>[]? includes)
        {
            var entity = _context.Set<TEntity>().IgnoreAutoIncludes();
            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    entity = entity.Include(include);
                }
            }
            return await entity.FirstOrDefaultAsync(conditions);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
