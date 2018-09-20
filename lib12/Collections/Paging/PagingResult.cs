namespace lib12.Collections.Paging
{
    public class PagingResult<T>
    {
        public int PageNumber { get; }
        public int ItemsPerPage { get; }
        public int TotalPages { get; }
        public T[] Items { get; }

        public PagingResult(int pageNumber, int itemsPerPage, int totalPages, T[] items)
        {
            PageNumber = pageNumber;
            ItemsPerPage = itemsPerPage;
            TotalPages = totalPages;
            Items = items;
        }
    }
}