namespace lib12.Data.QueryBuilding.Structures.Delete
{
    /// <summary>
    /// IDelete
    /// </summary>
    public interface IDelete
    {
        /// <summary>
        /// Adds FROM statement
        /// </summary>
        /// <param name="table">The source table</param>
        /// <returns></returns>
        IDeleteFrom From(string table);
    }

    /// <summary>
    /// IDeleteFrom
    /// </summary>
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.IBracketPossible" />
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.IWherePossible" />
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.IBuild" />
    public interface IDeleteFrom : IBracketPossible, IWherePossible, IBuild
    {

    }
}