namespace lib12.Data.Random
{
    /// <summary>
    /// Constrain for random int creation
    /// </summary>
    /// <seealso cref="lib12.Data.Random.RandDataConstrain" />
    public class IntConstrain : RandDataConstrain
    {
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public int MinValue { get; set; }
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public int MaxValue { get; set; }
    }
}