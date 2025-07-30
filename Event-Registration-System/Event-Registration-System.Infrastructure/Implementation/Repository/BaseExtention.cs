using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Implementation.Repository
{
    public static class BaseExtention
    {
        public static IQueryable<T> IncludesEntities<T>(this IQueryable<T> entity, params Expression<Func<T, object>>?[] includes)
            where T : class
        {
            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    if (entity != null && entity.Any() && include != null)
                    {
                        entity = entity.Include(include);
                    }
                }
            }

            return entity;
        }

        public static async Task<PagedList<T>> ToPagedList<T>(this IQueryable<T> source, QueryStringParameters parameters) where T : class
        {
            var totalCount = source.Count();
            var items = await source
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return new PagedList<T>(items, totalCount, parameters.PageNumber, parameters.PageSize);
        }
    }
}
