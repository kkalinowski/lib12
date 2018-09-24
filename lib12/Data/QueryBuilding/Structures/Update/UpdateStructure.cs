using System.Collections.Generic;

namespace lib12.Data.QueryBuilding.Structures.Update
{
    /// <summary>
    /// Represents update command that is currently build
    /// </summary>
    public class UpdateQueryStructure : BaseQueryStructure
    {
        /// <summary>
        /// Gets or sets the set fields.
        /// </summary>
        /// <value>
        /// The set fields.
        /// </value>
        public List<SetField> SetFields { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateQueryStructure"/> class.
        /// </summary>
        public UpdateQueryStructure()
        {
            SetFields = new List<SetField>();
        }
    }
}