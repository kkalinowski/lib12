
namespace lib12.Data.QueryBuilding.Structures.Select
{
    /// <summary>
    /// SelectField
    /// </summary>
    public class SelectField
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
        /// Gets or sets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        public string Alias { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has alias.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has alias; otherwise, <c>false</c>.
        /// </value>
        public bool HasAlias
        {
            get
            {
                return !string.IsNullOrEmpty(Alias);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectField"/> class.
        /// </summary>
        public SelectField()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectField"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        public SelectField(string field)
        {
            Field = field;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectField"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="alias">The alias.</param>
        public SelectField(string field, string alias)
        {
            Field = field;
            Alias = alias;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            return HasAlias ? string.Format("{0} AS {1}", Field, Alias) : Field;
        }
    }
}
