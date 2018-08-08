
namespace lib12.Data.QueryBuilding.Structures.Select
{
    /// <summary>
    /// SelectField
    /// </summary>
    public class SelectField
    {
        #region Props
        public string Field { get; set; }
        public string Alias { get; set; }

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
