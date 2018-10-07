using System.Collections.Generic;

namespace lib12.Data.QueryBuilding.Structures.Insert
{
    /// <summary>
    /// IInsert
    /// </summary>
    public interface IInsert
    {
        /// <summary>
        /// Adds INTO statement to INSERT
        /// </summary>
        /// <param name="table">The table to insert into</param>
        /// <returns></returns>
        IColumns Into(string table);
    }

    /// <summary>
    /// IColumns
    /// </summary>
    public interface IColumns
    {
        /// <summary>
        /// Adds the set of columns to insert into
        /// </summary>
        /// <param name="columns">The columns to insert</param>
        /// <returns></returns>
        IValues Columns(params string[] columns);

        /// <summary>
        /// Adds the sub SELECT statement to INSERT
        /// </summary>
        /// <param name="select">The sub select statement</param>
        /// <returns></returns>
        IBuild Select(string select);
    }

    /// <summary>
    /// IValues
    /// </summary>
    public interface IValues
    {
        /// <summary>
        /// Adds the VALUES statement to INSERT
        /// </summary>
        /// <param name="values">The set of values for INSERT</param>
        /// <returns></returns>
        IBuild Values(params object[] values);

        /// <summary>
        /// Adds several batches of VALUES statements to INSERT
        /// </summary>
        /// <param name="values">The values to add</param>
        /// <returns></returns>
        IBuild ValuesBatch(IEnumerable<object> values);

        /// <summary>
        /// Adds the sub SELECT statement to INSERT
        /// </summary>
        /// <param name="select">The sub select statement</param>
        /// <returns></returns>
        IBuild Select(string select);
    }
}