using lib12.Data.QueryBuilding.Structures.Delete;
using System.Text;

namespace lib12.Data.QueryBuilding.Builders
{
    public class DeleteBuilder : QueryBuilderBase<DeleteQueryStructure>, IDeleteFrom
    {
        public IDeleteFrom From(string table)
        {
            Structure.Table = table;
            return this;
        }

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