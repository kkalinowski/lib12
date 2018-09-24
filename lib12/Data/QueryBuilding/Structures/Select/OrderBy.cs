namespace lib12.Data.QueryBuilding.Structures.Select
{
    /// <summary>
    /// OrderBy
    /// </summary>
    public class OrderBy
    {
        #region Props
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public string Field { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OrderBy"/> is desc.
        /// </summary>
        /// <value>
        ///   <c>true</c> if desc; otherwise, <c>false</c>.
        /// </value>
        public bool Desc { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBy"/> class.
        /// </summary>
        public OrderBy()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBy"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="desc">if set to <c>true</c> [desc].</param>
        public OrderBy(string field, bool desc)
        {
            Field = field;
            Desc = desc;
        }
    }
}
