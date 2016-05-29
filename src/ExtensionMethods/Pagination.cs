using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
    public static class Pagination
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageIndex = 1, int pageSize = 20)
        {
            return source.Skip((pageIndex - 1)*pageSize).Take(pageSize);
        }
        public static IQueryable<T> Page<T>(this IQueryable<T> source, int pageIndex = 1, int pageSize = 20)
        {
            return source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
