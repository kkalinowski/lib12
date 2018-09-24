using System;
using System.Linq;
using System.Text;
using lib12.Data.QueryBuilding.Structures.Update;
using lib12.Extensions;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// UpdateBuilder
    /// </summary>
    /// <seealso cref="Builders.QueryBuilderBase{Structures.Update.UpdateQueryStructure}" />
    /// <seealso cref="Structures.Update.IUpdate" />
    /// <seealso cref="Structures.Update.IUpdateSet" />
    public class UpdateBuilder : QueryBuilderBase<UpdateQueryStructure>, IUpdate, IUpdateSet
    {
        /// <summary>
        /// Adds the TABLE statement to UPDATE
        /// </summary>
        /// <param name="table">The table name from DB for statement</param>
        /// <returns></returns>
        public IUpdateSet Table(string table)
        {
            Structure.Table = table;
            return this;
        }

        /// <summary>
        /// Adds the SET statement for UPDATe
        /// </summary>
        /// <param name="field">The field name to set</param>
        /// <param name="value">The value to set</param>
        /// <returns></returns>
        public IUpdateSet Set(string field, object value)
        {
            Structure.SetFields.Add(new SetField(field, value));
            return this;
        }

        #region Build
        public override string BuildQuery()
        {
            if (Structure.SetFields.Any(x => x.Field.IsNullOrEmpty()))
                throw new ArgumentException("Field cannot be null or empty");

            var sbuilder = new StringBuilder();
            sbuilder.AppendFormat("UPDATE {0} SET ", Structure.Table);

            BuildSet(sbuilder);

            if (Structure.MainCondition.IsValid)
            {
                whereBuilder.Build(sbuilder, Structure.MainCondition);
            }

            return sbuilder.ToString();
        }

        private void BuildSet(StringBuilder sbuilder)
        {
            foreach (var setfield in Structure.SetFields)
                sbuilder.AppendFormat("{0}='{1}', ", setfield.Field, setfield.Value);

            sbuilder.Remove(sbuilder.Length - 2, 2);
        }
        #endregion
    }
}