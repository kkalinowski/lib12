namespace lib12.Mathematics
{
    /// <summary>
    /// Number token
    /// </summary>
    public class NumberToken : Token
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public double Number { get; private set; }

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
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var b = obj as NumberToken;

            return b != null && this.Number == b.Number;
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