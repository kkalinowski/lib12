namespace lib12.Data.QueryBuilding.Builders
{
    public interface IUpdateSet : IBuild
    {
        IUpdateSet Set(string field, object value);
    }
}