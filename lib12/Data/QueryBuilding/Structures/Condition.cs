using System.Collections.Generic;
using lib12.Collections;

namespace lib12.Data.QueryBuilding.Structures
{
    /// <summary>
    /// Condition
    /// </summary>
    public class Condition
    {
        #region Props
        /// <summary>
        /// Gets or sets the field name
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public string Field { get; set; }
        /// <summary>
        /// Gets or sets the comparison type
        /// </summary>
        /// <value>
        /// The comparison.
        /// </value>
        public Compare Comparison { get; set; }
        /// <summary>
        /// Gets or sets the argument object
        /// </summary>
        /// <value>
        /// The argument.
        /// </value>
        public object Argument { get; set; }
        /// <summary>
        /// Gets or sets the sub-conditions
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public IList<Condition> Children { get; set; }
        /// <summary>
        /// Gets or sets the parent condition
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public Condition Parent { get; set; }
        /// <summary>
        /// Gets or sets the concat operator for joinging conditions
        /// </summary>
        /// <value>
        /// The concat.
        /// </value>
        public LogicOperator Concat { get; set; }
        /// <summary>
        /// Gets or sets the explicit string condition.
        /// </summary>
        /// <value>
        /// The explicit condition.
        /// </value>
        public string ExplicitCondition { get; set; }
        /// <summary>
        /// Gets a value indicating whether this instance has children.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has children; otherwise, <c>false</c>.
        /// </value>
        public bool HasChildren
        {
            get
            {
                return Children.IsNotEmpty();
            }
        }

        /// <summary>
        /// Returns true if condition is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid
        {
            get
            {
                return HasChildren || !(string.IsNullOrEmpty(Field) || Argument == null);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Condition"/> class.
        /// </summary>
        public Condition()
        {
            Children = new List<Condition>(2);
            Concat = LogicOperator.And;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Condition"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="comparison">The comparison.</param>
        /// <param name="argument">The argument.</param>
        public Condition(string field, Compare comparison, object argument)
        {
            Children = new List<Condition>(0);
            Concat = LogicOperator.And;
            Field = field;
            Comparison = comparison;
            Argument = argument;
        }

        /// <summary>
        /// Adds the child.
        /// </summary>
        /// <param name="cnd">The CND.</param>
        public void AddChild(Condition cnd)
        {
            Children.Add(cnd);
            cnd.Parent = this;
        }
    }
}
