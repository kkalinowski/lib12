namespace lib12.Data.QueryBuilding.Structures
{
    /// <summary>
    /// IBuild
    /// </summary>
    public interface IBuild
    {
        /// <summary>
        /// Builds whole sql query.
        /// </summary>
        /// <returns></returns>
        string Build();
    }
}