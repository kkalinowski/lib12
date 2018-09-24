namespace lib12.Collections.Paging
{
    /// <summary>
    /// PagingResult contains page with given number and collection statistics
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingResult<T>
    {
        /// <summary>
        /// Gets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        public int PageNumber { get; }
        /// <summary>
        /// Gets the items per page.
        /// </summary>
        /// <value>
        /// The items per page.
        /// </value>
        public int ItemsPerPage { get; }
        /// <summary>
        /// Gets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        public int TotalPages { get; }
        /// <summary>
        /// Gets the page items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public T[] Items { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingResult{T}"/> class.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <param name="totalPages">The total pages.</param>
        /// <param name="items">The items.</param>
        public PagingResult(int pageNumber, int itemsPerPage, int totalPages, T[] items)
        {
            PageNumber = pageNumber;
            ItemsPerPage = itemsPerPage;
            TotalPages = totalPages;
            Items = items;
        }
    }
}