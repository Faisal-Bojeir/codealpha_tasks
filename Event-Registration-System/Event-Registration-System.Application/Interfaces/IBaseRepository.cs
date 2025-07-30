using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByConditionAsync(
            Expression<Func<T, bool>> condition,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includes
        );
        Task<PagedList<T>> GetRangeByConditionAsync(
            Expression<Func<T, bool>> condition,
            QueryStringParameters parameters,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includes
        );

        Task<T> UpdateAsync(T entity);

        Task<T> CreateAsync(T entity);
    }
}
