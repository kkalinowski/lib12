using System;

namespace lib12.Data.Random
{
    /// <summary>
    /// Constrain containg factory method to create new values
    /// </summary>
    /// <seealso cref="lib12.Data.Random.RandDataConstrain" />
    public class FactoryMethodConstrain : RandDataConstrain
    {
        /// <summary>
        /// Gets or sets the factory method to cfreate new values
        /// </summary>
        /// <value>
        /// The factory method.
        /// </value>
        public Func<object> FactoryMethod { get; set; }
    }
}