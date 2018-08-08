
namespace lib12.Data.QueryBuilding.Structures.Select
{
    /// <summary>
    /// Join
    /// </summary>
    public class Join
    {
        #region Props
        public string LeftField { get; set; }
        public string RightTable { get; set; }
        public string RightTableAlias { get; set; }
        public string RightField { get; set; }
        public JoinType Type { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Join"/> class.
        /// </summary>
        /// <param name="rightTable">The right table.</param>
        /// <param name="rightTableAlias">The right table alias.</param>
        /// <param name="leftField">The left field.</param>
        /// <param name="rightField">The right field.</param>
        /// <param name="type">The type.</param>
        public Join(string rightTable, string rightTableAlias, string leftField, string rightField, JoinType type)
        {
            LeftField = leftField;
            RightTable = rightTable;
            RightTableAlias = rightTableAlias;
            RightField = rightField;
            Type = type;
        }
    }
}
