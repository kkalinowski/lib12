namespace lib12.Data.QueryBuilding
{
    /// <summary>
    /// QueryBuilderException
    /// </summary>
    /// <seealso cref="lib12.lib12Exception" />
    public class QueryBuilderException : lib12Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilderException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public QueryBuilderException(string message)
            : base(message)
        {

        }
    }
}
