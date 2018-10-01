namespace lib12.Mathematics.Formulas
{
    /// <summary>
    /// Number token
    /// </summary>
    public class NumberToken : Token
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public double Number { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberToken"/> class.
        /// </summary>
        /// <param name="number">The number.</param>
        public NumberToken(double number)
        {
            Number = number;
            Type = TokenType.Number;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is NumberToken b && Number == b.Number;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (int)Number + (int)Type;
        }
    }
}