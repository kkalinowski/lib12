
namespace lib12.Data.QueryBuilding.Structures
{
    public class Join
    {
        #region Props
        public string LeftField { get; set; }
        public string RightTable { get; set; }
        public string RightTableAlias { get; set; }
        public string RightField { get; set; }
        public JoinType Type { get; set; }
        #endregion

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
