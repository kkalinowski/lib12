using System.Collections.Generic;

namespace lib12.Data.QueryBuilding.Structures.Select
{
    /// <summary>
    /// Contains select data to build query
    /// </summary>
    public class SelectStructure
    {
        #region Props
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SelectStructure"/> is distinct.
        /// </summary>
        /// <value>
        ///   <c>true</c> if distinct; otherwise, <c>false</c>.
        /// </value>
        public bool Distinct { get; set; }
        /// <summary>
        /// Gets or sets the top result count.
        /// </summary>
        /// <value>
        /// The top count.
        /// </value>
        public int TopCount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [all fields].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [all fields]; otherwise, <c>false</c>.
        /// </value>
        public bool AllFields { get; set; }
        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public List<SelectField> Fields { get; }
        /// <summary>
        /// Gets or sets the main table.
        /// </summary>
        /// <value>
        /// The main table.
        /// </value>
        public string MainTable { get; set; }
        /// <summary>
        /// Gets or sets the main table alias.
        /// </summary>
        /// <value>
        /// The main table alias.
        /// </value>
        public string MainTableAlias { get; set; }
        /// <summary>
        /// Gets the joins.
        /// </summary>
        /// <value>
        /// The joins.
        /// </value>
        public List<Join> Joins { get; }
        /// <summary>
        /// Gets or sets the main condition.
        /// </summary>
        /// <value>
        /// The main condition.
        /// </value>
        public Condition MainCondition { get; set; }
        /// <summary>
        /// Gets the group by fields.
        /// </summary>
        /// <value>
        /// The group by fields.
        /// </value>
        public List<string> GroupByFields { get; }
        /// <summary>
        /// Gets or sets the having.
        /// </summary>
        /// <value>
        /// The having.
        /// </value>
        public string Having { get; set; }
        /// <summary>
        /// Gets the order by fields.
        /// </summary>
        /// <value>
        /// The order by fields.
        /// </value>
        public List<OrderBy> OrderByFields { get; }
        #endregion Props

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectStructure"/> class.
        /// </summary>
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
