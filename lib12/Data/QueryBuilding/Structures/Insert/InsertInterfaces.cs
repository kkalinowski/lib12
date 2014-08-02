using System.Collections.Generic;

namespace lib12.Data.QueryBuilding.Structures.Insert
{
    public interface IInsert
    {
        IColumns Into(string table);
    }

    public interface IColumns
    {
        IValues Columns(params string[] columns);
        IBuild Select(string select);
    }

    public interface IValues
    {
        IBuild Values(params object[] values);
        IBuild Batch(IEnumerable<object> values);
        IBuild Select(string select);
    }
}