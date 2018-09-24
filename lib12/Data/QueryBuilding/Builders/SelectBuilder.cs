using System;
using System.Collections.Generic;
using System.Text;
using lib12.Collections;
using lib12.Data.QueryBuilding.Structures;
using lib12.Data.QueryBuilding.Structures.Select;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// SelectBuilder
    /// </summary>
    /// <seealso cref="Structures.Select.ISelect" />
    /// <seealso cref="Structures.Select.IFields" />
    /// <seealso cref="Structures.Select.ISelectFrom" />
    /// <seealso cref="Structures.Select.IOpenSelectBracket" />
    /// <seealso cref="Structures.Select.ICloseSelectBracket" />
    /// <seealso cref="Structures.Select.ISelectWhere" />
    /// <seealso cref="Structures.Select.ISelectConcat" />
    /// <seealso cref="Structures.Select.IGroupBy" />
    /// <seealso cref="Structures.Select.IHaving" />
    /// <seealso cref="Structures.Select.IOrderBy" />
    public class SelectBuilder : ISelect, IFields, ISelectFrom, IOpenSelectBracket, ICloseSelectBracket, ISelectWhere, ISelectConcat, IGroupBy, IHaving, IOrderBy
    {
        #region Fields
        private int openBrackets;
        private Condition parent;
        private Condition lastCnd;
        private readonly WhereBuilder whereBuilder;
        #endregion

        #region Props
        /// <summary>
        /// Gets or sets the select structure being build
        /// </summary>
        /// <value>
        /// The structure.
        /// </value>
        public SelectStructure Structure { get; set; }
        /// <summary>
        /// Gets or sets the type of the database.
        /// </summary>
        /// <value>
        /// The type of the database.
        /// </value>
        public DBType DBType { get; set; }
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectBuilder"/> class.
        /// </summary>
        public SelectBuilder()
        {
            DBType = DBType.MsSql;
            Structure = new SelectStructure();
            whereBuilder = new WhereBuilder();
            parent = Structure.MainCondition;
            lastCnd = parent;
        }
        #endregion

        #region Build query

        /// <inheritdoc />
        public string Build()
        {
            if (openBrackets > 0)
                throw new QueryBuilderException("Not all brackets are closed");
            else if (openBrackets < 0)
                throw new QueryBuilderException("Too many closed brackets");

            var sbuilder = new StringBuilder();
            sbuilder.Append("SELECT ");

            if (Structure.Distinct)
                sbuilder.Append("DISTINCT ");

            if (DBType == DBType.MsSql && Structure.TopCount > 0)
                sbuilder.AppendFormat("TOP {0} ", Structure.TopCount);

            //fields
            if (Structure.AllFields)
                sbuilder.Append("* ");
            else
                BuildFields(sbuilder);

            //from
            if (!Structure.MainTable.Contains(" "))
                sbuilder.AppendFormat("FROM {0}", Structure.MainTable);
            else
                sbuilder.AppendFormat("FROM \"{0}\"", Structure.MainTable);
            if (!string.IsNullOrEmpty(Structure.MainTableAlias))
                sbuilder.AppendFormat(" {0}", Structure.MainTableAlias);

            //joins
            if (Structure.Joins.IsNotEmpty())
                BuildJoins(sbuilder);

            //where
            if (Structure.MainCondition.IsValid)
            {
                whereBuilder.Build(sbuilder, Structure.MainCondition);
            }

            //group by
            if (Structure.GroupByFields.IsNotEmpty())
            {
                BuildGroupBy(sbuilder);
                if (!string.IsNullOrEmpty(Structure.Having))
                    sbuilder.AppendFormat(" HAVING {0}", Structure.Having);
            }

            //order by
            if (Structure.OrderByFields.IsNotEmpty())
            {
                BuildOrderBy(sbuilder);
            }

            if (DBType != DBType.MsSql && Structure.TopCount > 0)
                sbuilder.AppendFormat(" LIMIT {0}", Structure.TopCount);

            return sbuilder.ToString();
        }

        private void BuildFields(StringBuilder sbuilder)
        {
            foreach (var field in Structure.Fields)
            {
                sbuilder.AppendFormat("{0}, ", field.Build());
            }
            sbuilder.Remove(sbuilder.Length - 2, 1);
        }

        private void BuildJoins(StringBuilder sbuilder)
        {
            foreach (var join in Structure.Joins)
            {
                switch (join.Type)
                {
                    case JoinType.Standard:
                        sbuilder.AppendFormat(" JOIN");
                        break;
                    case JoinType.Left:
                        sbuilder.AppendFormat(" LEFT JOIN");
                        break;
                    case JoinType.Right:
                        sbuilder.AppendFormat(" RIGHT JOIN");
                        break;
                    default:
                        throw new QueryBuilderException("Unknown join type");
                }

                sbuilder.AppendFormat(" {0} {1} ON {2}={3}", join.RightTable, join.RightTableAlias, join.LeftField, join.RightField);
            }
        }

        private void BuildGroupBy(StringBuilder sbuilder)
        {
            sbuilder.Append(" GROUP BY ");

            for (int i = 0; i < Structure.GroupByFields.Count; i++)
            {
                sbuilder.Append(Structure.GroupByFields[i]);
                if (i != Structure.GroupByFields.Count - 1)
                    sbuilder.Append(", ");
            }
        }

        private void BuildOrderBy(StringBuilder sbuilder)
        {
            sbuilder.Append(" ORDER BY ");

            for (int i = 0; i < Structure.OrderByFields.Count; i++)
            {
                sbuilder.Append(Structure.OrderByFields[i].Field);
                if (Structure.OrderByFields[i].Desc)
                    sbuilder.Append(" DESC");
                if (i != Structure.OrderByFields.Count - 1)
                    sbuilder.Append(", ");
            }
        }
        #endregion

        #region Fluent implementation
        /// <summary>
        /// Set the type of database
        /// </summary>
        /// <param name="dbType">Type of the database.</param>
        /// <returns></returns>
        public SelectBuilder DB(DBType dbType)
        {
            DBType = dbType;
            return this;
        }

        #region Fields
        /// <summary>
        /// Is query distinct
        /// </summary>
        /// <value>
        /// The distinct.
        /// </value>
        public SelectBuilder Distinct
        {
            get
            {
                Structure.Distinct = true;
                return this;
            }
        }

        /// <inheritdoc />
        public IFields AllFields
        {
            get
            {
                Structure.AllFields = true;
                return this;
            }
        }

        /// <inheritdoc />
        public IFields Fields(IEnumerable<SelectField> fields)
        {
            Structure.Fields.AddRange(fields);
            return this;
        }

        /// <inheritdoc />
        public IFields Fields(params string[] fields)
        {
            return Fields(false, fields);
        }

        /// <inheritdoc />
        public IFields Fields(bool withAlias, params string[] fields)
        {
            if (withAlias && fields.Length % 2 != 0)
                throw new QueryBuilderException("Must be same number of fields and aliases");

            for (int i = 0; i < fields.Length; i++)
            {
                if (withAlias)
                    Structure.Fields.Add(new SelectField(fields[i], fields[++i]));
                else
                    Structure.Fields.Add(new SelectField(fields[i]));
            }

            return this;
        }
        #endregion

        #region From

        /// <inheritdoc />
        public ITop Top(int count)
        {
            Structure.TopCount = count;
            return this;
        }

        /// <inheritdoc />
        public ISelectFrom From(string table)
        {
            Structure.MainTable = table;
            return this;
        }

        /// <inheritdoc />
        public ISelectFrom From(string table, string alias)
        {
            Structure.MainTable = table;
            Structure.MainTableAlias = alias;
            return this;
        }
        #endregion

        #region Join
        /// <inheritdoc />
        public ISelectFrom Join(Join join)
        {
            Structure.Joins.Add(join);
            return this;
        }

        /// <inheritdoc />
        public ISelectFrom Join(string rightTable, string rightTableAlias, string leftField, string rightField)
        {
            var join = new Join(rightTable, rightTableAlias, leftField, rightField, JoinType.Standard);
            return ((ISelectFrom)this).Join(join);
        }

        /// <inheritdoc />
        public ISelectFrom Join(string rightTable, string rightTableAlias, string leftField, string rightField, JoinType type)
        {
            var join = new Join(rightTable, rightTableAlias, leftField, rightField, type);
            return ((ISelectFrom)this).Join(join);
        }
        #endregion

        #region Where
        /// <inheritdoc />
        public IOpenSelectBracket OpenBracket()
        {
            openBrackets++;
            var cnd = new Condition();
            parent.AddChild(cnd);
            parent = cnd;
            return this;
        }

        /// <inheritdoc />
        public ICloseSelectBracket CloseBracket()
        {
            openBrackets--;
            lastCnd = parent.Parent != Structure.MainCondition ? parent.Parent : parent;
            parent = parent.Parent;
            return this;
        }

        /// <inheritdoc />
        public ISelectWhere Where(Condition cnd)
        {
            parent.AddChild(cnd);
            lastCnd = cnd;
            return this;
        }

        /// <inheritdoc />
        public ISelectWhere Where(string field, Compare comparison, object argument)
        {
            var cnd = new Condition(field, comparison, argument);
            return ((ISelectFrom)this).Where(cnd);
        }

        /// <inheritdoc />
        public ISelectWhere Where(string condition)
        {
            var cnd = new Condition { ExplicitCondition = condition };
            return ((ISelectFrom)this).Where(cnd);
        }

        /// <inheritdoc />
        public ISelectWhere WhereBetween(string field, object argument1, object argument2)
        {
            var cnd = new Condition(field, Compare.Between, new Tuple<object, object>(argument1, argument2));
            return ((ISelectFrom)this).Where(cnd);
        }

        /// <inheritdoc />
        public ISelectWhere WhereIsNull(string field)
        {
            var cnd = new Condition(field, Compare.IsNull, null);
            return ((ISelectFrom)this).Where(cnd);
        }

        /// <inheritdoc />
        public ISelectWhere WhereIsNotNull(string field)
        {
            var cnd = new Condition(field, Compare.IsNotNull, null);
            return ((ISelectFrom)this).Where(cnd);
        }

        /// <inheritdoc />
        public ISelectConcat And
        {
            get
            {
                lastCnd.Concat = LogicOperator.And;
                return this;
            }
        }

        /// <inheritdoc />
        public ISelectConcat Or
        {
            get
            {
                lastCnd.Concat = LogicOperator.Or;
                return this;
            }
        }
        #endregion

        #region Group, having, order
        /// <inheritdoc />
        public IGroupBy GroupBy(string field)
        {
            Structure.GroupByFields.Add(field);
            return this;
        }

        /// <inheritdoc />
        public IHaving Having(string cnd)
        {
            Structure.Having = cnd;
            return this;
        }

        /// <inheritdoc />
        public IOrderBy OrderBy(string field)
        {
            Structure.OrderByFields.Add(new OrderBy(field, false));
            return this;
        }

        /// <inheritdoc />
        public IOrderBy OrderBy(OrderBy orderBy)
        {
            Structure.OrderByFields.Add(orderBy);
            return this;
        }

        /// <inheritdoc />
        public IOrderBy OrderByDesc(string field)
        {
            Structure.OrderByFields.Add(new OrderBy(field, true));
            return this;
        }
        #endregion
        #endregion
    }
}
