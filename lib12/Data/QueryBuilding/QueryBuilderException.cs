using lib12.Exceptions;

namespace lib12.Data.QueryBuilding
{
    public class QueryBuilderException : lib12Exception
    {
        public QueryBuilderException(string message)
            : base(message)
        {

        }
    }
}
