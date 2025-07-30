using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.Common
{
    public static class PagedListExtensions
    {
        public static PagedList<TResult> Map<TSource, TResult>(
            this PagedList<TSource> source,
            Func<TSource, TResult> selector)
        {
            var mappedItems = source.Items.Select(selector).ToList();

            return new PagedList<TResult>(
                mappedItems,
                source.TotalCount,
                source.CurrentPage,
                source.PageSize
            );
        }
    }
}
