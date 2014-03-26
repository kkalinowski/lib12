using lib12.Data.QueryBuilding.Structures.Delete;

namespace lib12.Data.QueryBuilding.Structures.Update
{
    public interface IUpdateSet : IBracketPossible, IWherePossible, IBuild
    {
        IUpdateSet Set(string field, object value);
    }    
}