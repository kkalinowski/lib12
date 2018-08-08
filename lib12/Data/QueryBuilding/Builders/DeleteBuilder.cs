using System.Text;
using lib12.Data.QueryBuilding.Structures.Delete;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// DeleteBuilder
    /// </summary>
    /// <seealso cref="lib12.Data.QueryBuilding.Builders.QueryBuilderBase{lib12.Data.QueryBuilding.Structures.Delete.DeleteQueryStructure}" />
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.Delete.IDelete" />
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.Delete.IDeleteFrom" />
    public class DeleteBuilder : QueryBuilderBase<DeleteQueryStructure>, IDelete, IDeleteFrom
    {
        /// <summary>
        /// Adds FROM statement
        /// </summary>
        /// <param name="table">The source table</param>
        /// <returns></returns>
        public IDeleteFrom From(string table)
        {
            Structure.Table = table;
            return this;
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        public override string BuildQuery()
        {
            var sbuilder = new StringBuilder();
            sbuilder.AppendFormat("DELETE FROM {0}", Structure.Table);

            if (Structure.MainCondition.IsValid)
            {
                whereBuilder.Build(sbuilder, Structure.MainCondition);
            }

            return sbuilder.ToString();
        }
    }
}