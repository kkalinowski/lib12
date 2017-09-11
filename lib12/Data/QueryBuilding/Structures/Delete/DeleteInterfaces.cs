namespace lib12.Data.QueryBuilding.Structures.Delete
{
    public interface IDelete
    {
        /// <summary>
        /// Adds FROM statement
        /// </summary>
        /// <param name="table">The source table</param>
        /// <returns></returns>
        IDeleteFrom From(string table);
    }

    public interface IDeleteFrom : IBracketPossible, IWherePossible, IBuild
    {

    }
}