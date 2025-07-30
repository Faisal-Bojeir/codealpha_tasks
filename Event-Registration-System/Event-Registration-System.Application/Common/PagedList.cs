using Event_Registration_System.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.Common
{
    public class PagedList<T>
    {
        public List<T> Items { get; }
        public int TotalCount { get; }
        public int PageSize { get; }
        public int CurrentPage { get; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
        }
    }
}
