namespace lib12.Mathematics
{
    /// <summary>
    /// Variable token
    /// </summary>
    public class VariableToken : Token
    {
        /// <summary>
        /// Gets the variable.
        /// </summary>
        public string Variable { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableToken"/> class.
        /// </summary>
        /// <param name="variable">The variable.</param>
        public VariableToken(string variable)
        {
            Variable = variable;
            Type = TokenType.Variable;
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
            var b = obj as VariableToken;

            return b != null && this.Variable == b.Variable;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Variable.GetHashCode() + (int)Type;
        }
    }
}