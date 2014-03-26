using System;

namespace lib12.Data.QueryBuilding.Structures.Select
{
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


    public interface ISelectWherePossible
    {
        ISelectWhere Where(Condition cnd);
        ISelectWhere Where(string field, Compare comparison, object argument);
        ISelectWhere WhereBetween(string field, object argument1, object argument2);
        ISelectWhere WhereBetween(string field, Tuple<object, object> argument);
        ISelectWhere WhereIsNull(string field);
        ISelectWhere WhereIsNotNull(string field);
    }

    public interface ISelectBracketPossible
    {
        IOpenSelectBracket OpenBracket();
    }

    public interface ISelectConcatPossible
    {
        ISelectConcat And { get; }
        ISelectConcat Or { get; }
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

    public interface IFrom : ISelectBracketPossible, ISelectWherePossible, IGroupByPossible, IOrderByPossible, IBuild
    {
        IFrom Join(Join join);
        IFrom Join(string rightTable, string rightTableAlias, string leftField, string rightField);
        IFrom Join(string rightTable, string rightTableAlias, string leftField, string rightField, JoinType type);
    }

    public interface IOpenSelectBracket : ISelectWherePossible
    {

    }

    public interface ICloseSelectBracket : ISelectConcatPossible, IGroupByPossible, IOrderByPossible, IBuild
    {

    }

    public interface ISelectConcat : ISelectBracketPossible, ISelectWherePossible
    {

    }

    public interface ISelectWhere : ISelectConcatPossible, IGroupByPossible, IOrderByPossible, IBuild
    {
        ICloseSelectBracket CloseBracket();
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
