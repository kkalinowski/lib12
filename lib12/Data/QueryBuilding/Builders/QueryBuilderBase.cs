using System;
using lib12.Data.QueryBuilding.Structures;
using lib12.Extensions;

namespace lib12.Data.QueryBuilding.Builders
{
    /// <summary>
    /// QueryBuilderBase
    /// </summary>
    /// <typeparam name="TStructure">The type of the structure.</typeparam>
    /// <seealso cref="Structures.IOpenBracket" />
    /// <seealso cref="Structures.ICloseBracket" />
    /// <seealso cref="Structures.IWhere" />
    /// <seealso cref="Structures.IConcat" />
    public abstract class QueryBuilderBase<TStructure> : IOpenBracket, ICloseBracket, IWhere, IConcat
        where TStructure : BaseQueryStructure, new()
    {
        protected int openBrackets;
        protected Condition parent;
        protected Condition lastCnd;
        protected WhereBuilder whereBuilder;

        public TStructure Structure { get; set; }

        protected QueryBuilderBase()
        {
            whereBuilder = new WhereBuilder();
            Structure = new TStructure();
            parent = Structure.MainCondition;
            lastCnd = parent;
        }

        public IConcat And
        {
            get
            {
                lastCnd.Concat = LogicOperator.And;
                return this;
            }
        }

        public IConcat Or
        {
            get
            {
                lastCnd.Concat = LogicOperator.Or;
                return this;
            }
        }

        public IOpenBracket OpenBracket()
        {
            openBrackets++;
            var cnd = new Condition();
            parent.AddChild(cnd);
            parent = cnd;
            return this;
        }

        public ICloseBracket CloseBracket()
        {
            openBrackets--;
            lastCnd = parent.Parent != Structure.MainCondition ? parent.Parent : parent;
            parent = parent.Parent;
            return this;
        }

        public IWhere Where(Condition cnd)
        {
            parent.AddChild(cnd);
            lastCnd = cnd;
            return this;
        }

        public IWhere Where(string condition)
        {
            var cnd = new Condition { ExplicitCondition = condition };
            return Where(cnd);
        }

        public IWhere Where(string field, Compare comparison, object argument)
        {
            var cnd = new Condition(field, comparison, argument);
            return Where(cnd);
        }

        public IWhere WhereBetween(string field, object argument1, object argument2)
        {
            var cnd = new Condition(field, Compare.Between, new Tuple<object, object>(argument1, argument2));
            return Where(cnd);
        }

        public IWhere WhereBetween(string field, Tuple<object, object> argument)
        {
            var cnd = new Condition(field, Compare.Between, argument);
            return Where(cnd);
        }

        public IWhere WhereIsNull(string field)
        {
            var cnd = new Condition(field, Compare.IsNull, null);
            return Where(cnd);
        }

        public IWhere WhereIsNotNull(string field)
        {
            var cnd = new Condition(field, Compare.IsNotNull, null);
            return Where(cnd);
        }

        public string Build()
        {
            if (Structure.Table.IsNullOrEmpty())
                throw new ArgumentException("Table cannot be null or empty");

            if (openBrackets > 0)
                throw new QueryBuilderException("Not all brackets are closed");
            else if (openBrackets < 0)
                throw new QueryBuilderException("Too many closed brackets");

            return BuildQuery();
        }

        public abstract string BuildQuery();

    }
}