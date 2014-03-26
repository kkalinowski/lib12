using System;
using lib12.Data.QueryBuilding.Builders;
using lib12.Data.QueryBuilding.Structures.Select;

namespace lib12.Data.QueryBuilding.Structures.Update
{
    public interface IUpdateSet : IBracketPossible, IWherePossible, IBuild
    {
        IUpdateSet Set(string field, object value);
    }

    public interface IWherePossible
    {
        IWhere Where(Condition cnd);
        IWhere Where(string field, Compare comparison, object argument);
        IWhere WhereBetween(string field, object argument1, object argument2);
        IWhere WhereBetween(string field, Tuple<object, object> argument);
        IWhere WhereIsNull(string field);
        IWhere WhereIsNotNull(string field);
    }

    public interface IBracketPossible
    {
        IOpenBracket OpenBracket();
    }

    public interface IConcatPossible
    {
        IConcat And { get; }
        IConcat Or { get; }
    }

    public interface IOpenBracket : IWherePossible
    {

    }

    public interface ICloseBracket : IConcatPossible, IGroupByPossible, IOrderByPossible, IBuild
    {

    }

    public interface IConcat : IBracketPossible, IWherePossible
    {

    }

    public interface IWhere : IConcatPossible, IGroupByPossible, IOrderByPossible, IBuild
    {
        ICloseBracket CloseBracket();
    }
}