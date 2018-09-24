namespace lib12.Data.QueryBuilding.Structures.Update
{
    /// <summary>
    /// UPDATE statement table interface
    /// </summary>
    public interface IUpdate
    {
        /// <summary>
        /// Adds the TABLE statement to UPDATE
        /// </summary>
        /// <param name="table">The table name from DB for statement</param>
        /// <returns></returns>
        IUpdateSet Table(string table);
    }

    /// <summary>
    /// UPDATE statement SET interface
    /// </summary>
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.IBracketPossible" />
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.IWherePossible" />
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.IBuild" />
    public interface IUpdateSet : IBracketPossible, IWherePossible, IBuild
    {
        /// <summary>
        /// Adds the SET statement for UPDATe
        /// </summary>
        /// <param name="field">The field name to set</param>
        /// <param name="value">The value to set</param>
        /// <returns></returns>
        IUpdateSet Set(string field, object value);
    }
}