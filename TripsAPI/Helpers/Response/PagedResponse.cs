using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsAPI.Helpers.Response
{
    public class PagedResponse<T>
    {
        public PagedResponse() { }
        public PagedResponse(IEnumerable<T> results)
        {
            Results = results;
        }
        public IEnumerable<T> Results { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public int PageCount { get; set; }
        public int RecordCount { get; set; }
    }
}
