namespace lib12.Data.QueryBuilding.Structures.Insert
{
    public interface IInto
    {
        IColumns Into(string table);
    }

    public interface IColumns
    {
        IValues Columns(params string[] columns);
    }

    public interface IValues
    {
        IBuild Values(params object[] values);
    }
}