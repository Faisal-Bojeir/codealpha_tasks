using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.EF.Interface
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetRangeByConditionAsync(Expression<Func<TEntity, bool>> conditions, params Expression<Func<TEntity, object>>[]? includes);
        Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}
