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
        public string Field { get; set; }
        public Compare Comparison { get; set; }
        public object Argument { get; set; }
        public IList<Condition> Children { get; set; }
        public Condition Parent { get; set; }
        public LogicOperator Concat { get; set; }
        public string ExplicitCondition { get; set; }
        public bool HasChildren
        {
            get
            {
                return Children.IsNotEmpty();
            }
        }

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
