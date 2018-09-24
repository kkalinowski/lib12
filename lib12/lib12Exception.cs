using System;

namespace lib12
{
    /// <summary>
    /// Base class for all exceptions in lib12 library
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class lib12Exception : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="lib12Exception"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public lib12Exception(string message) : base(message)
        {
        }
    }
}
