namespace lib12.Data.QueryBuilding.Builders
{
    public interface IUpdateSet : IBracketPossible, IWherePossible, IBuild
    {
        IUpdateSet Set(string field, object value);
    }
}