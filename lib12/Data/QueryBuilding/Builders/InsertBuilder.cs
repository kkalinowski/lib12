using lib12.Data.QueryBuilding.Structures;
using lib12.Data.QueryBuilding.Structures.Insert;
using System.Text;

namespace lib12.Data.QueryBuilding.Builders
{
    public class InsertBuilder : QueryBuilderBase<InsertStructure>, IInto, IColumns, IValues
    {
        public IColumns Into(string table)
        {
            Structure.Table = table;
            return this;
        }

        public IValues Columns(params string[] columns)
        {
            Structure.Columns = columns;
            return this;
        }

        public IBuild Values(params object[] values)
        {
            Structure.Values = values;
            return this;
        }

        public override string BuildQuery()
        {
            if (Structure.Columns.Length != Structure.Values.Length)
                throw new QueryBuilderException("Columns count differs from values count");

            var sbuilder = new StringBuilder();
            sbuilder.AppendFormat("INSERT INTO {0}({1}) VALUES({2})", Structure.Table, BuildColumns(), BuildValues());

            return sbuilder.ToString();
        }

        private string BuildColumns()
        {
            var sbuilder = new StringBuilder();
            foreach (var column in Structure.Columns)
                sbuilder.AppendFormat("{0}, ", column);

            sbuilder.Remove(sbuilder.Length - 2, 2);
            return sbuilder.ToString();
        }

        private string BuildValues()
        {
            var sbuilder = new StringBuilder();
            foreach (var value in Structure.Values)
                sbuilder.AppendFormat("'{0}', ", value);

            sbuilder.Remove(sbuilder.Length - 2, 2);
            return sbuilder.ToString();
        }
    }
}