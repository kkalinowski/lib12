using System;
using System.Collections.Generic;
using System.Linq;

namespace lib12.Collections.Paging
{
    public static class PagingExtension
    {
        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> source, int page, int itemsPerPage)
        {
            return null;
        }

        public static int GetNumberOfPages<T>(this IEnumerable<T> source, int itemsPerPage)
        {
            var itemsCount = (double)source.Recover().Count();
            return (int)Math.Ceiling(itemsCount / itemsPerPage);
        }
    }
}