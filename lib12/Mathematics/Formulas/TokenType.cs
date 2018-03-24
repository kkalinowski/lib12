namespace lib12.Mathematics.Formulas
{
    /// <summary>
    /// Type of reverse polish notation token
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// The number token
        /// </summary>
        Number,
        /// <summary>
        /// The operator token
        /// </summary>
        Operator,
        /// <summary>
        /// The negation token
        /// </summary>
        Negation,
        /// <summary>
        /// The variable token
        /// </summary>
        Variable
    }
}