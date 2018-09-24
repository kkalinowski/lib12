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
    /// <seealso cref="Structures.IBracketPossible" />
    /// <seealso cref="Structures.IWherePossible" />
    /// <seealso cref="Structures.IBuild" />
    public interface IDeleteFrom : IBracketPossible, IWherePossible, IBuild
    {

    }
}