namespace lib12.Data.Random
{
    /// <summary>
    /// Constrain for random double creation
    /// </summary>
    /// <seealso cref="lib12.Data.Random.RandDataConstrain" />
    public class DoubleConstrain : RandDataConstrain
    {
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public double MinValue { get; set; }
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public double MaxValue { get; set; }
    }
}