
namespace lib12.Data.QueryBuilding.Structures.Select
{
    /// <summary>
    /// Join
    /// </summary>
    public class Join
    {
        #region Props
        /// <summary>
        /// Gets or sets the left field.
        /// </summary>
        /// <value>
        /// The left field.
        /// </value>
        public string LeftField { get; set; }
        /// <summary>
        /// Gets or sets the right table.
        /// </summary>
        /// <value>
        /// The right table.
        /// </value>
        public string RightTable { get; set; }
        /// <summary>
        /// Gets or sets the right table alias.
        /// </summary>
        /// <value>
        /// The right table alias.
        /// </value>
        public string RightTableAlias { get; set; }
        /// <summary>
        /// Gets or sets the right field.
        /// </summary>
        /// <value>
        /// The right field.
        /// </value>
        public string RightField { get; set; }
        /// <summary>
        /// Gets or sets the join type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public JoinType Type { get; set; }
        #endregion Props

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
