using System;
using System.Linq;
using System.Text;
using lib12.Collections;
using lib12.Data.QueryBuilding.Structures;
using lib12.Data.QueryBuilding.Structures.Update;

namespace lib12.Data.QueryBuilding.Builders
{
    public class UpdateBuilder : IUpdateSet, IBracketPossible, IWherePossible, IBuild
    {
        public UpdateStructure Structure { get; set; }

        public UpdateBuilder()
        {
            Structure = new UpdateStructure();
        }

        public IUpdateSet Table(string table)
        {
            Structure.MainTable = table;
            return this;
        }

        public IUpdateSet Set(string field, object value)
        {
            Structure.SetFields.Add(new SetField(field, value));
            return this;
        }

        #region Build
        public string Build()
        {
            if (Structure.MainTable.IsNullOrEmpty())
                throw new ArgumentException("Table cannot be null or empty");

            if (Structure.SetFields.Any(x => x.Field.IsNullOrEmpty()))
                throw new ArgumentException("Field cannot be null or empty");

            var sbuilder = new StringBuilder();
            sbuilder.AppendFormat("UPDATE {0} SET ", Structure.MainTable);

            BuildSet(sbuilder);

            return sbuilder.ToString();
        }

        private void BuildSet(StringBuilder sbuilder)
        {
            foreach (var setfield in Structure.SetFields)
                sbuilder.AppendFormat("{0}='{1}', ", setfield.Field, setfield.Value);

            sbuilder.Remove(sbuilder.Length - 2, 2);
        }
        #endregion

        public IOpenBracket OpenBracket()
        {
            throw new NotImplementedException();
        }

        public IWhere Where(Condition cnd)
        {
            throw new NotImplementedException();
        }

        public IWhere Where(string field, Compare comparison, object argument)
        {
            throw new NotImplementedException();
        }

        public IWhere WhereBetween(string field, object argument1, object argument2)
        {
            throw new NotImplementedException();
        }

        public IWhere WhereBetween(string field, Tuple<object, object> argument)
        {
            throw new NotImplementedException();
        }

        public IWhere WhereIsNull(string field)
        {
            throw new NotImplementedException();
        }

        public IWhere WhereIsNotNull(string field)
        {
            throw new NotImplementedException();
        }
    }
}