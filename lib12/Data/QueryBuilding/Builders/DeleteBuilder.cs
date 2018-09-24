using System.Text;
using lib12.Data.QueryBuilding.Structures.Delete;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// DeleteBuilder
    /// </summary>
    /// <seealso cref="Builders.QueryBuilderBase{Structures.Delete.DeleteQueryStructure}" />
    /// <seealso cref="Structures.Delete.IDelete" />
    /// <seealso cref="Structures.Delete.IDeleteFrom" />
    public class DeleteBuilder : QueryBuilderBase<DeleteQueryStructure>, IDelete, IDeleteFrom
    {
        /// <inheritdoc />
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