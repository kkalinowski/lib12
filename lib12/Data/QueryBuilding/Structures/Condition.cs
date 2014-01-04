using System.Collections.Generic;
using lib12.Collections;

namespace lib12.Data.QueryBuilding.Structures
{
    public class Condition
    {
        #region Props
        public string Field { get; set; }
        public Compare Comparison { get; set; }
        public object Argument { get; set; }
        public IList<Condition> Children { get; set; }
        public Condition Parent { get; set; }
        public LogicOperator Concat { get; set; }

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

        public Condition()
        {
            Children = new List<Condition>(2);
            Concat = LogicOperator.And;
        }

        public Condition(string field, Compare comparison, object argument)
        {
            Children = new List<Condition>(0);
            Concat = LogicOperator.And;
            Field = field;
            Comparison = comparison;
            Argument = argument;
        }

        public void AddChild(Condition cnd)
        {
            Children.Add(cnd);
            cnd.Parent = this;
        }
    }
}
