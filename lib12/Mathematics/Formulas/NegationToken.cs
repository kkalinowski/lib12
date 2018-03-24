namespace lib12.Mathematics.Formulas
{
    /// <summary>
    /// Negation token
    /// </summary>
    public class NegationToken : Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NegationToken"/> class.
        /// </summary>
        public NegationToken()
        {
            Type = TokenType.Negation;
        }
    }
}