using System.Collections.Generic;
using lib12.Collections;
using lib12.Data.QueryBuilding.Structures;
using lib12.Data.QueryBuilding.Structures.Insert;
using System.Text;
using lib12.Extensions;
using lib12.Reflection;

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

        public IBuild Batch(IEnumerable<object> values)
        {
            if (values.Null())
                throw new QueryBuilderException("Collection of values to batch insert cannot be null");
            if (values.IsEmpty())
                throw new QueryBuilderException("Collection of values to batch insert cannot be empty");

            Structure.BatchValues = values;
            return this;
        }

        public override string BuildQuery()
        {
            if (!Structure.IsBatchInsert && Structure.Columns.Length != Structure.Values.Length)
                throw new QueryBuilderException("Columns count differs from values count");

            var sbuilder = new StringBuilder();
            sbuilder.AppendFormat("INSERT INTO {0}({1}) ", Structure.Table, BuildColumns());
            if (Structure.IsBatchInsert)
                sbuilder.Append(BuildBatchInsertValues());
            else
                sbuilder.Append(BuildInsertValues());

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

        private string BuildInsertValues()
        {
            var sbuilder = new StringBuilder("VALUES(");
            foreach (var value in Structure.Values)
                sbuilder.AppendFormat("'{0}', ", value);

            sbuilder.Remove(sbuilder.Length - 2, 2);
            sbuilder.Append(")");
            return sbuilder.ToString();
        }

        private string BuildBatchInsertValues()
        {
            var sbuilder = new StringBuilder();
            sbuilder.Append("VALUES");
            foreach (var item in Structure.BatchValues)
            {
                sbuilder.Append("(");
                foreach (var column in Structure.Columns)
                    sbuilder.AppendFormat("'{0}', ", item.GetType().GetPropertyValue(item, column));

                sbuilder.Remove(sbuilder.Length - 2, 2);
                sbuilder.Append("), ");
            }

            sbuilder.Remove(sbuilder.Length - 2, 2);
            return sbuilder.ToString();
        }
    }
}