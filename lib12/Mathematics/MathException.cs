namespace lib12.Mathematics
{
    /// <summary>
    /// MathException
    /// </summary>
    /// <seealso cref="lib12.lib12Exception" />
    public class MathException : lib12Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MathException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MathException(string message)
            : base(message)
        {

        }
    }
}