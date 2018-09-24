using System;
using System.Collections.Generic;
using System.Linq;

namespace lib12.Collections.Paging
{
    public static class PagingExtension
    {
        public static PagingResult<T> GetPage<T>(this IEnumerable<T> source, int pageNumber, int itemsPerPage)
        {
            if (pageNumber < 1)
                throw new lib12Exception($"Page numbers start at one, you provided {pageNumber}");

            if (itemsPerPage < 1)
                throw new lib12Exception($"Must have at least one item per pageNumber, you provided {itemsPerPage}");

            var numberOfPages = GetNumberOfPages(source, itemsPerPage);
            if(pageNumber > numberOfPages && source.IsNotNullAndNotEmpty())
                throw new lib12Exception($"Page numbers can't be higher than page count. At this moment page number is {pageNumber}, when number of pages is {numberOfPages}");

            var pageItems = GetPageItems(source, pageNumber, itemsPerPage);
            return new PagingResult<T>(pageNumber, itemsPerPage, numberOfPages, pageItems);
        }

        public static int GetNumberOfPages<T>(IEnumerable<T> source, int itemsPerPage)
        {
            var itemsCount = (double)source.Recover().Count();
            return (int)Math.Ceiling(itemsCount / itemsPerPage);
        }

        public static T[] GetPageItems<T>(IEnumerable<T> source, int pageNumber, int itemsPerPage)
        {
            return source
                .Recover()
                .Skip(itemsPerPage * (pageNumber - 1))
                .Take(itemsPerPage)
                .ToArray();
        }
    }
}