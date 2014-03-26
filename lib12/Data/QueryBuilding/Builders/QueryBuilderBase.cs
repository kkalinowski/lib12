using System;
using lib12.Data.QueryBuilding.Structures;

namespace lib12.Data.QueryBuilding.Builders
{
    public class QueryBuilderBase //: IOpenBracket, ICloseBracket, IWhere, IConcat
    {
        protected int openBrackets;
        protected Condition parent;
        protected Condition lastCnd;
        protected WhereBuilder whereBuilder;

        //public IConcat And
        //{
        //    get
        //    {
        //        lastCnd.Concat = LogicOperator.And;
        //        return this;
        //    }
        //}

        //public IConcat Or
        //{
        //    get
        //    {
        //        lastCnd.Concat = LogicOperator.Or;
        //        return this;
        //    }
        //}

        //public IOpenBracket OpenBracket()
        //{
        //    openBrackets++;
        //    var cnd = new Condition();
        //    parent.AddChild(cnd);
        //    parent = cnd;
        //    return this;
        //}

        //public ICloseBracket CloseBracket()
        //{
        //    openBrackets--;
        //    lastCnd = parent.Parent != Structure.MainCondition ? parent.Parent : parent;
        //    parent = parent.Parent;
        //    return this;
        //}

        //public IWhere Where(Condition cnd)
        //{
        //    parent.AddChild(cnd);
        //    lastCnd = cnd;
        //    return this;
        //}

        //public IWhere Where(string field, Compare comparison, object argument)
        //{
        //    var cnd = new Condition(field, comparison, argument);
        //    return ((IFrom)this).Where(cnd);
        //}

        //public IWhere WhereBetween(string field, object argument1, object argument2)
        //{
        //    var cnd = new Condition(field, Compare.Between, new Tuple<object, object>(argument1, argument2));
        //    return ((IFrom)this).Where(cnd);
        //}

        //public IWhere WhereBetween(string field, Tuple<object, object> argument)
        //{
        //    var cnd = new Condition(field, Compare.Between, argument);
        //    return ((IFrom)this).Where(cnd);
        //}

        //public IWhere WhereIsNull(string field)
        //{
        //    var cnd = new Condition(field, Compare.IsNull, null);
        //    return ((IFrom)this).Where(cnd);
        //}

        //public IWhere WhereIsNotNull(string field)
        //{
        //    var cnd = new Condition(field, Compare.IsNotNull, null);
        //    return ((IFrom)this).Where(cnd);
        //}
    }
}