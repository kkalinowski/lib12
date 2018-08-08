using System.Collections.Generic;
using lib12.Collections;

namespace lib12.Data.QueryBuilding.Structures.Insert
{
    /// <summary>
    /// InsertStructure
    /// </summary>
    /// <seealso cref="lib12.Data.QueryBuilding.Structures.BaseQueryStructure" />
    public class InsertStructure : BaseQueryStructure
    {
        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        /// <value>
        /// The columns.
        /// </value>
        public string[] Columns { get; set; }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public object[] Values { get; set; }

        /// <summary>
        /// Gets or sets the batch values.
        /// </summary>
        /// <value>
        /// The batch values.
        /// </value>
        public IEnumerable<object> BatchValues { get; set; }

        /// <summary>
        /// Gets or sets the select.
        /// </summary>
        /// <value>
        /// The select.
        /// </value>
        public string Select { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is batch insert.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is batch insert; otherwise, <c>false</c>.
        /// </value>
        public bool IsBatchInsert
        {
            get { return BatchValues.IsNotNullAndNotEmpty(); }
        }
    }
}