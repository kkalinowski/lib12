
namespace lib12.Utility
{
    /// <summary>
    /// Exception to thrown when handling unknown enum type
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <seealso cref="lib12.lib12Exception" />
    public class UnknownEnumException<TEnum> : lib12Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownEnumException{TEnum}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public UnknownEnumException(TEnum value)
            : base(string.Format("Unknown enum value {0} of type {1}", value.ToString(), value.GetType().Name))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownEnumException{TEnum}"/> class.
        /// </summary>
        public UnknownEnumException()
            : base(string.Format("Unknown enum value of type {0}", typeof(TEnum).Name))
        {
        }
    }
}
