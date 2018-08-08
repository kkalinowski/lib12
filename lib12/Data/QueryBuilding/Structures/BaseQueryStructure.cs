namespace lib12.Data.QueryBuilding.Structures
{
    /// <summary>
    /// BaseQueryStructure
    /// </summary>
    public abstract class BaseQueryStructure
    {
        /// <summary>
        /// Gets or sets the main table.
        /// </summary>
        /// <value>
        /// The main table.
        /// </value>
        public string Table { get; set; }

        /// <summary>
        /// Gets or sets the main WHERE condition.
        /// </summary>
        /// <value>
        /// The main condition.
        /// </value>
        public Condition MainCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseQueryStructure"/> class.
        /// </summary>
        protected BaseQueryStructure()
        {
            MainCondition = new Condition();
        }
    }
}