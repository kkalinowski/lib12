using lib12.Data.QueryBuilding.Structures.Delete;
using lib12.Data.QueryBuilding.Structures.Insert;
using lib12.Data.QueryBuilding.Structures.Select;
using lib12.Data.QueryBuilding.Structures.Update;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// Fluent sql commands builder
    /// </summary>
    public class SqlBuilder
    {
        /// <summary>
        /// Builds SELECT query
        /// </summary>
        public static ISelect Select
        {
            get
            {
                return new SelectBuilder();
            }
        }

        /// <summary>
        /// Builds UPDATE command
        /// </summary>
        public static IUpdate Update
        {
            get
            {
                return new UpdateBuilder();
            }
        }

        /// <summary>
        /// Builds DELETE command
        /// </summary>
        public static IDelete Delete
        {
            get
            {
                return new DeleteBuilder();
            }
        }


        /// <summary>
        /// Builds INSERT command
        /// </summary>
        public static IInsert Insert
        {
            get
            {
                return new InsertBuilder();
            }
        }
    }
}
