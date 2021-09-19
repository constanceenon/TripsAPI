using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsAPI.Helpers.Response
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            CurrentPage = 1;
            PageSize = 2;
            SortBy = 1;
        }
        public PaginationQuery(int pageNumber, int pageSize, string searchText, int sortBy)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize > 100 ? 100 : pageSize;
            SearchText = searchText;
            SortBy = sortBy;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
        public int SortBy { get; set; }
        public int? Filter { get; set; }
        public int? Status { get; set; }
    }
}
