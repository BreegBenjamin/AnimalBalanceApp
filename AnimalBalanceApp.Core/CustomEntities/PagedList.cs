using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalBalanceApp.Core.CustomEntities
{
    public class PagedList<T> :List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextsPage => CurrentPage < TotalPages;
        public int? NextPageNumber => HasNextsPage ? CurrentPage + 1 : null;
        public int? PreviusPageNumber => HasPreviousPage ? CurrentPage - 1 : null;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalPages = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize) 
        {
            int count = source.Count();
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items,count,pageNumber,pageSize);
        }
    }
}
