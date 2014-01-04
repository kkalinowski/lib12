using System;
using lib12.Data.QueryBuilding.Structures;

namespace lib12.Data.QueryBuilding.Builders
{
    public interface IBuild
    {
        string Build();
    }

    public interface IFields : ITop
    {
        ITop Top(int count);
    }

    public interface ITop
    {
        IFrom From(string table);
        IFrom From(string table, string alias);
    }

    #region Possibilites
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

    public interface IGroupByPossible
    {
        IGroupBy GroupBy(string field);
    }

    public interface IOrderByPossible
    {
        IOrderBy OrderBy(string field);
        IOrderBy OrderBy(OrderBy orderBy);
        IOrderBy OrderByDesc(string field);
    }
    #endregion

    public interface IFrom : IBracketPossible, IWherePossible, IGroupByPossible, IOrderByPossible, IBuild
    {
        IFrom Join(Join join);
        IFrom Join(string rightTable, string rightTableAlias, string leftField, string rightField);
        IFrom Join(string rightTable, string rightTableAlias, string leftField, string rightField, JoinType type);
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

    public interface IGroupBy : IGroupByPossible, IOrderByPossible, IBuild
    {
        IHaving Having(string cnd);
    }

    public interface IHaving : IOrderByPossible, IBuild
    {

    }

    public interface IOrderBy : IBuild
    {

    }
}
