namespace lib12.Data.QueryBuilding.Structures.Delete
{
    public interface IDelete
    {
        IDeleteFrom From(string table);
    }

    public interface IDeleteFrom : IBracketPossible, IWherePossible, IBuild
    {

    }
}