using System.Collections.Generic;

namespace lib12.Data.QueryBuilding.Structures.Select
{
    public class SelectStructure
    {
        #region Props
        public bool Distinct { get; set; }
        public int TopCount { get; set; }
        public bool AllFields { get; set; }
        public List<SelectField> Fields { get; private set; }
        public string MainTable { get; set; }
        public string MainTableAlias { get; set; }
        public List<Join> Joins { get; private set; }
        public Condition MainCondition { get; set; }
        public List<string> GroupByFields { get; private set; }
        public string Having { get; set; }
        public List<OrderBy> OrderByFields { get; private set; }
        #endregion

        public SelectStructure()
        {
            Fields = new List<SelectField>();
            Joins = new List<Join>();
            MainCondition = new Condition();
            GroupByFields = new List<string>();
            OrderByFields = new List<OrderBy>();
        }
    }
}
