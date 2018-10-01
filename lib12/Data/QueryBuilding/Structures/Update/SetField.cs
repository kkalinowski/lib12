namespace lib12.Data.QueryBuilding.Structures.Update
{
    /// <summary>
    /// Represents set field in update command
    /// </summary>
    public class SetField
    {
        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the field value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetField"/> class.
        /// </summary>
        public SetField()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetField"/> class.
        /// </summary>
        /// <param name="field">The field name.</param>
        /// <param name="value">The field value.</param>
        public SetField(string field, object value)
        {
            Field = field;
            Value = value;
        }
    }
}