using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRMManagement.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; private set; }

        //
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);
        //public int FirstItemIndex => (PageIndex - 1) * Pagesize + 1;
        //public int LastItemIndex => Math.Min(PageIndex * Pagesize, TotalItems);

        public static PaginatedList<T> Create(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();  //
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
