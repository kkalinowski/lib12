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
        /// <summary>
        /// The open brackets count
        /// </summary>
        protected int openBrackets;
        /// <summary>
        /// The parent condition
        /// </summary>
        protected Condition parent;
        /// <summary>
        /// The last condition
        /// </summary>
        protected Condition lastCnd;
        /// <summary>
        /// The where statement builder
        /// </summary>
        protected WhereBuilder whereBuilder;

        /// <summary>
        /// Gets or sets the structure build
        /// </summary>
        /// <value>
        /// The structure.
        /// </value>
        public TStructure Structure { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilderBase{TStructure}"/> class.
        /// </summary>
        protected QueryBuilderBase()
        {
            whereBuilder = new WhereBuilder();
            Structure = new TStructure();
            parent = Structure.MainCondition;
            lastCnd = parent;
        }

        /// <inheritdoc />        
        public IConcat And
        {
            get
            {
                lastCnd.Concat = LogicOperator.And;
                return this;
            }
        }

        /// <inheritdoc />
        public IConcat Or
        {
            get
            {
                lastCnd.Concat = LogicOperator.Or;
                return this;
            }
        }

        /// <inheritdoc />
        public IOpenBracket OpenBracket()
        {
            openBrackets++;
            var cnd = new Condition();
            parent.AddChild(cnd);
            parent = cnd;
            return this;
        }

        /// <inheritdoc />
        public ICloseBracket CloseBracket()
        {
            openBrackets--;
            lastCnd = parent.Parent != Structure.MainCondition ? parent.Parent : parent;
            parent = parent.Parent;
            return this;
        }

        /// <inheritdoc />
        public IWhere Where(Condition cnd)
        {
            parent.AddChild(cnd);
            lastCnd = cnd;
            return this;
        }

        /// <inheritdoc />
        public IWhere Where(string condition)
        {
            var cnd = new Condition { ExplicitCondition = condition };
            return Where(cnd);
        }

        /// <inheritdoc />
        public IWhere Where(string field, Compare comparison, object argument)
        {
            var cnd = new Condition(field, comparison, argument);
            return Where(cnd);
        }

        /// <inheritdoc />
        public IWhere WhereBetween(string field, object argument1, object argument2)
        {
            var cnd = new Condition(field, Compare.Between, new Tuple<object, object>(argument1, argument2));
            return Where(cnd);
        }

        /// <inheritdoc />
        public IWhere WhereIsNull(string field)
        {
            var cnd = new Condition(field, Compare.IsNull, null);
            return Where(cnd);
        }

        /// <inheritdoc />
        public IWhere WhereIsNotNull(string field)
        {
            var cnd = new Condition(field, Compare.IsNotNull, null);
            return Where(cnd);
        }

        /// <inheritdoc />
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

        /// <summary>
        /// Builds the query and returns result as string
        /// </summary>
        /// <returns></returns>
        public abstract string BuildQuery();
    }
}