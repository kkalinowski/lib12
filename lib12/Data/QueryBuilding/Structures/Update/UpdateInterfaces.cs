namespace lib12.Data.QueryBuilding.Structures.Update
{
    public interface IUpdate
    {
        IUpdateSet Table(string table);
    }

    public interface IUpdateSet : IBracketPossible, IWherePossible, IBuild
    {
        IUpdateSet Set(string field, object value);
    }
}