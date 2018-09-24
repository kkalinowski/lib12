using System.Collections.Generic;
using System.Text;
using lib12.Collections;
using lib12.Data.QueryBuilding.Structures;
using lib12.Data.QueryBuilding.Structures.Insert;
using lib12.Extensions;
using lib12.Reflection;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// InsertBuilder
    /// </summary>
    /// <seealso cref="Structures.Insert.IInsert" />
    /// <seealso cref="Structures.Insert.IColumns" />
    /// <seealso cref="Structures.Insert.IValues" />
    public class InsertBuilder : QueryBuilderBase<InsertStructure>, IInsert, IColumns, IValues
    {
        /// <summary>
        /// Adds INTO statement to INSERT
        /// </summary>
        /// <param name="table">The table to insert into</param>
        /// <returns></returns>
        public IColumns Into(string table)
        {
            Structure.Table = table;
            return this;
        }

        /// <summary>
        /// Adds the set of columns to insert into
        /// </summary>
        /// <param name="columns">The columns to insert</param>
        /// <returns></returns>
        public IValues Columns(params string[] columns)
        {
            Structure.Columns = columns;
            return this;
        }

        /// <summary>
        /// Adds the sub SELECT statement to INSERT
        /// </summary>
        /// <param name="select">The sub select statement</param>
        /// <returns></returns>
        /// <exception cref="QueryBuilderException">Select statement cannot be null or empty</exception>
        public IBuild Select(string select)
        {
            if (select.IsNullOrEmpty())
                throw new QueryBuilderException("Select statement cannot be null or empty");

            Structure.Select = select;
            return this;
        }

        /// <summary>
        /// Adds the VALUES statement to INSERT
        /// </summary>
        /// <param name="values">The set of values for INSERT</param>
        /// <returns></returns>
        public IBuild Values(params object[] values)
        {
            Structure.Values = values;
            return this;
        }

        /// <summary>
        /// Adds several batches of VALUES statements to INSERT
        /// </summary>
        /// <param name="values">The values to add</param>
        /// <returns></returns>
        /// <exception cref="QueryBuilderException">Collection of values to batch insert cannot be null or empty</exception>
        public IBuild ValuesBatch(IEnumerable<object> values)
        {
            if (values.IsNullOrEmpty())
                throw new QueryBuilderException("Collection of values to batch insert cannot be null or empty");

            Structure.BatchValues = values;
            return this;
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="QueryBuilderException">Columns count differs from values count</exception>
        public override string BuildQuery()
        {
            if (Structure.Select.IsNotNullAndNotEmpty() && Structure.Columns.IsNullOrEmpty())
                return $"INSERT INTO {Structure.Table} {Structure.Select}";
            else if (Structure.Select.IsNotNullAndNotEmpty())
                return $"INSERT INTO {Structure.Table}({BuildColumns()}) {Structure.Select}";

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