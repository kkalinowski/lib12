using System;
using System.Collections.Generic;
using System.Linq;

namespace lib12.Collections.Paging
{
    /// <summary>
    /// PagingExtension
    /// </summary>
    public static class PagingExtension
    {
        /// <summary>
        /// Gets the page from the collection with paging statistics
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source collection</param>
        /// <param name="pageNumber">The page number</param>
        /// <param name="itemsPerPage">Items per page</param>
        /// <returns></returns>
        /// <exception cref="lib12Exception">
        /// </exception>
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

        /// <summary>
        /// Gets the number of pages from the collection given specific itemsPerPage count
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source collection</param>
        /// <param name="itemsPerPage">Items per page</param>
        /// <returns></returns>
        public static int GetNumberOfPages<T>(this IEnumerable<T> source, int itemsPerPage)
        {
            var itemsCount = (double)source.Recover().Count();
            return (int)Math.Ceiling(itemsCount / itemsPerPage);
        }

        /// <summary>
        /// Gets only the page content without computing paging statistics
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source collection</param>
        /// <param name="pageNumber">The page number</param>
        /// <param name="itemsPerPage">Items per page</param>
        /// <returns></returns>
        public static T[] GetPageItems<T>(this IEnumerable<T> source, int pageNumber, int itemsPerPage)
        {
            return source
                .Recover()
                .Skip(itemsPerPage * (pageNumber - 1))
                .Take(itemsPerPage)
                .ToArray();
        }
    }
}