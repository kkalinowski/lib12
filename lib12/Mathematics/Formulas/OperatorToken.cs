namespace lib12.Mathematics.Formulas
{
    /// <summary>
    /// Operator token
    /// </summary>
    public class OperatorToken : Token
    {
        /// <summary>
        /// Gets the operator type.
        /// </summary>
        public OperatorType Operator { get; private set; }

        /// <summary>
        /// Gets the operator priority.
        /// </summary>
        public int Priority { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorToken"/> class.
        /// </summary>
        /// <param name="op">The operator</param>
        public OperatorToken(OperatorType op)
        {
            Operator = op;
            Type = TokenType.Operator;

            switch (Operator)
            {
                case OperatorType.Plus:
                    Priority = 1;
                    break;
                case OperatorType.Minus:
                    Priority = 1;
                    break;
                case OperatorType.Mult:
                    Priority = 2;
                    break;
                case OperatorType.Div:
                    Priority = 2;
                    break;
                case OperatorType.LeftBraket:
                    Priority = 0;
                    break;
                case OperatorType.RightBraket:
                    break;
                default:
                    break;
            }
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
            var b = obj as OperatorToken;

            return b != null && this.Operator == b.Operator;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (int)Operator + (int)Type;
        }
    }
}