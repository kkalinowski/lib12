using lib12.Data.QueryBuilding.Structures.Delete;
using lib12.Data.QueryBuilding.Structures.Insert;
using lib12.Data.QueryBuilding.Structures.Select;
using lib12.Data.QueryBuilding.Structures.Update;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// Fluent sql commands builder
    /// </summary>
    public static class SqlBuilder
    {
        /// <summary>
        /// Builds SELECT query
        /// </summary>
        public static ISelect Select => new SelectBuilder();

        /// <summary>
        /// Builds UPDATE command
        /// </summary>
        public static IUpdate Update => new UpdateBuilder();

        /// <summary>
        /// Builds DELETE command
        /// </summary>
        public static IDelete Delete => new DeleteBuilder();

        /// <summary>
        /// Builds INSERT command
        /// </summary>
        public static IInsert Insert => new InsertBuilder();
    }
}
