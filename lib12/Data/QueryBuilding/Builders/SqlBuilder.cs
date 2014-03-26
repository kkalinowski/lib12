
namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// Fluent sql commands builder
    /// </summary>
    public class SqlBuilder
    {
        /// <summary>
        /// Builds select query
        /// </summary>
        public static SelectBuilder Select
        {
            get
            {
                return new SelectBuilder();
            }
        }

        /// <summary>
        /// Builds update command
        /// </summary>
        public static UpdateBuilder Update
        {
            get
            {
                return new UpdateBuilder();
            }
        }

        /// <summary>
        /// Builds delete command
        /// </summary>
        public static DeleteBuilder Delete
        {
            get
            {
                return new DeleteBuilder();
            }
        }
    }
}
