using System.Collections.Generic;

namespace lib12.Data.QueryBuilding.Structures.Update
{
    /// <summary>
    /// Represents update command that is currently build
    /// </summary>
    public class UpdateStructure
    {
        /// <summary>
        /// Gets or sets the main table.
        /// </summary>
        /// <value>
        /// The main table.
        /// </value>
        public string MainTable { get; set; }

        /// <summary>
        /// Gets or sets the set fields.
        /// </summary>
        /// <value>
        /// The set fields.
        /// </value>
        public List<SetField> SetFields { get; set; }

        /// <summary>
        /// Gets or sets the main WHERE condition.
        /// </summary>
        /// <value>
        /// The main condition.
        /// </value>
        public Condition MainCondition { get; set; }

        public UpdateStructure()
        {
            SetFields = new List<SetField>();
            MainCondition = new Condition();
        }
    }
}