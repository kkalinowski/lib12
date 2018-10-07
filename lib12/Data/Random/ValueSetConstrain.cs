using System.Collections;

namespace lib12.Data.Random
{
    /// <summary>
    /// Contains values constrains 
    /// </summary>
    /// <seealso cref="lib12.Data.Random.RandDataConstrain" />
    public class ValueSetConstrain : RandDataConstrain
    {
        /// <summary>
        /// Gets or sets the available values to choose from
        /// </summary>
        /// <value>
        /// The available values.
        /// </value>
        public IEnumerable AvailableValues { get; set; }
    }
}