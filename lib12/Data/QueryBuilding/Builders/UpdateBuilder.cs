using System;
using System.Linq;
using System.Text;
using lib12.Data.QueryBuilding.Structures.Update;
using lib12.Extensions;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// Update statement builder
    /// </summary>
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.Update.IUpdate" />
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.Update.IUpdateSet" />
    public class UpdateBuilder : QueryBuilderBase<UpdateQueryStructure>, IUpdate, IUpdateSet
    {
        /// <inheritdoc />
        public IUpdateSet Table(string table)
        {
            Structure.Table = table;
            return this;
        }

        /// <inheritdoc />
        public IUpdateSet Set(string field, object value)
        {
            Structure.SetFields.Add(new SetField(field, value));
            return this;
        }

        #region Build
        /// <inheritdoc />
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