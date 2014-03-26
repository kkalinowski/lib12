using System;
using System.Collections;
using System.Linq;
using System.Text;
using lib12.Collections;
using lib12.Data.QueryBuilding.Structures;
using lib12.Exceptions;
using lib12.Extensions;

namespace lib12.Data.QueryBuilding.Builders
{
    public class WhereBuilder
    {
        public void Build(StringBuilder sbuilder, Condition condition)
        {
            sbuilder.Append(" WHERE ");
            BuildConditionWithChildren(sbuilder, condition, condition);
        }

        private void BuildConditionWithChildren(StringBuilder sbuilder, Condition mainCondition, Condition cnd)
        {
            if (cnd.Children.Count == 1)
            {
                BuildCondition(sbuilder, cnd.Children.First());
            }
            else
            {
                if (cnd != mainCondition)
                    sbuilder.Append("(");

                for (int i = 0; i < cnd.Children.Count; i++)
                {
                    if (cnd.Children[i].HasChildren)
                        BuildConditionWithChildren(sbuilder, mainCondition, cnd.Children[i]);
                    else
                        BuildCondition(sbuilder, cnd.Children[i]);
                    if (i != cnd.Children.Count - 1)
                        sbuilder.AppendFormat(" {0} ", cnd.Children[i].Concat == LogicOperator.And ? "AND" : "OR");
                }

                if (cnd != mainCondition)
                    sbuilder.Append(")");
            }
        }

        private void BuildCondition(StringBuilder sbuilder, Condition cnd)
        {
            var quote = cnd.Argument.ToString().StartsWith("@") ? string.Empty : "'";
            if (cnd.Comparison == Compare.IsNull || cnd.Comparison == Compare.IsNotNull)
            {
                sbuilder.AppendFormat("{0}{1}", cnd.Field, BuildComparison(cnd.Comparison));
            }
            else if (cnd.Comparison == Compare.StartsWith)
            {
                sbuilder.AppendFormat("{0} LIKE {1}{2}%{1}", cnd.Field, quote, cnd.Argument);
            }
            else if (cnd.Comparison == Compare.EndsWith)
            {
                sbuilder.AppendFormat("{0} LIKE {1}%{2}{1}", cnd.Field, quote, cnd.Argument);
            }
            else if (cnd.Comparison == Compare.Between)
            {
                var tuple = (Tuple<object, object>)cnd.Argument;
                sbuilder.AppendFormat("{0}{1}{2}{3}{2} AND {2}{4}{2}", cnd.Field, BuildComparison(cnd.Comparison), quote, tuple.Item1, tuple.Item2);
            }
            else if (cnd.Comparison == Compare.In || cnd.Comparison == Compare.NotIn)
            {
                var args = cnd.Argument as IEnumerable;
                if (args.Null())
                    throw new lib12Exception("You have to pass IEnumerable to condition with IN statement");

                var argsArray = args.Cast<object>().ToArray();
                if (argsArray.IsEmpty())
                {
                    sbuilder.Append("1 = 1");
                    return;
                }

                sbuilder.AppendFormat("{0}{1}(", cnd.Field, BuildComparison(cnd.Comparison));

                foreach (var arg in argsArray)
                {
                    sbuilder.AppendFormat("{0}{1}{0}, ", quote, arg);
                }
                sbuilder.Remove(sbuilder.Length - 2, 2);
                sbuilder.Append(")");
            }
            else
                sbuilder.AppendFormat("{0}{1}{2}{3}{2}", cnd.Field, BuildComparison(cnd.Comparison), quote, cnd.Argument);
        }

        private string BuildComparison(Compare comparison)
        {
            switch (comparison)
            {
                case Compare.Equals:
                    return "=";
                case Compare.NotEquals:
                    return "!=";
                case Compare.Like:
                    return " LIKE ";
                case Compare.NotLike:
                    return " NOT LIKE ";
                case Compare.GreaterThan:
                    return ">";
                case Compare.GreaterOrEquals:
                    return ">=";
                case Compare.LessThan:
                    return "<";
                case Compare.LessOrEquals:
                    return "<=";
                case Compare.In:
                    return " IN ";
                case Compare.NotIn:
                    return " NOT IN ";
                case Compare.Between:
                    return " BETWEEN ";
                case Compare.IsNull:
                    return " IS NULL";
                case Compare.IsNotNull:
                    return " IS NOT NULL";
                default:
                    throw new QueryBuilderException("Unknown comparison");
            }
        }
    }
}