using System;

namespace lib12.Data.QueryBuilding.Structures
{
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

    public interface ICloseBracket : IConcatPossible, IBuild
    {

    }

    public interface IConcat : IBracketPossible, IWherePossible
    {

    }

    public interface IWhere : IConcatPossible, IBuild
    {
        ICloseBracket CloseBracket();
    }
}