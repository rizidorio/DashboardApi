using System.Collections.Generic;

namespace Dashboard.Data.Utils
{
    public static class PaginatedResult
    {
        public static PaginatedModel<T> Paginate<T>(this IEnumerable<T> source, int pageSize, int pageNumber)
        {
            return new PaginatedModel<T>(pageNumber, pageSize).Paginate(source);
        }
    }
}
