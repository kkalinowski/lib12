using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using lib12.Collections;
using lib12.Exceptions;
using lib12.Extensions;

namespace lib12.Mathematics
{
    /// <summary>
    /// Mathematics formulas parser and calculator using reverse polish notation
    /// </summary>
    public class Formula
    {
        /// <summary>
        /// Gets the formula's text.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets the reverse polish notation tokens.
        /// </summary>
        public ReadOnlyCollection<Token> Tokens { get; private set; }

        /// <summary>
        /// Gets a value indicating whether formula is vali
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Formula"/> class.
        /// </summary>
        /// <param name="text">The formula's text.</param>
        public Formula(string text)
        {
            Text = text;
            var tokens = Parse(Text);
            if (tokens.NotNull())
            {
                Tokens = new ReadOnlyCollection<Token>(tokens);
                IsValid = true;
            }
        }

        /// <summary>
        /// Parses formula
        /// </summary>
        /// <param name="text">The formula's text.</param>
        /// <returns></returns>
        private List<Token> Parse(string text)
        {
            var token = new StringBuilder();
            var stack = new Stack<OperatorToken>();
            var output = new List<Token>();
            var negationPossible = true;//true if next minus means negation

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i])
                    || text[i].ToString(Thread.CurrentThread.CurrentCulture) == Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                {
                    token.Clear();
                    token.Append(text[i]);
                    while (text.Length >= i + 2 && (char.IsDigit(text[i + 1])
                        || text[i + 1].ToString(Thread.CurrentThread.CurrentCulture) == Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                    {
                        token.Append(text[i + 1]);
                        ++i;
                    }

                    output.Add(new NumberToken(double.Parse(token.ToString())));
                    negationPossible = false;
                }
                else if (text[i] == '+')
                {
                    AddOperatorToStack(stack, output, new OperatorToken(OperatorType.Plus));
                    negationPossible = true;
                }
                else if (text[i] == '-')
                {
                    if (negationPossible)
                    {
                        output.Add(new NegationToken());
                        negationPossible = false;
                    }
                    else
                    {
                        AddOperatorToStack(stack, output, new OperatorToken(OperatorType.Minus));
                    }
                }
                else if (text[i] == '*')
                {
                    AddOperatorToStack(stack, output, new OperatorToken(OperatorType.Mult));
                    negationPossible = true;
                }
                else if (text[i] == '/')
                {
                    AddOperatorToStack(stack, output, new OperatorToken(OperatorType.Div));
                    negationPossible = true;
                }
                else if (text[i] == '(')
                {
                    AddOperatorToStack(stack, output, new OperatorToken(OperatorType.LeftBraket));
                    negationPossible = true;
                }
                else if (text[i] == ')')
                {
                    AddOperatorToStack(stack, output, new OperatorToken(OperatorType.RightBraket));
                    negationPossible = false;
                }
                else if (char.IsLetter(text[i]))
                {
                    token.Clear();
                    token.Append(text[i]);
                    while (text.Length >= i + 2 && char.IsLetter(text[i + 1]))
                    {
                        token.Append(text[i + 1]);
                        ++i;
                    }

                    output.Add(new VariableToken(token.ToString()));
                    negationPossible = false;
                }
                else if (char.IsWhiteSpace(text[i]))
                    continue;
                else // unknown symbol in formula
                    return null;
            }

            //clear stack from operators
            while (stack.IsNotEmpty())
                output.Add(stack.Pop());

            //left and right brackets count must be equal
            var operators = output.Where(x => x.Type.Is(TokenType.Operator)).Cast<OperatorToken>().ToArray();
            if (operators.Count(x => x.Operator.Is(OperatorType.LeftBraket)) != operators.Count(x => x.Operator.Is(OperatorType.RightBraket)))
                return null;

            //in order to evaluate reverse polish notation it must be exactly one more literal than operator
            if (operators.Count(x => x.Operator.IsNot(OperatorType.LeftBraket, OperatorType.RightBraket)) != output.Count(x => x.Type.Is(TokenType.Number, TokenType.Variable)) - 1)
                return null;

            return output;
        }

        /// <summary>
        /// Adds the RPN operator to stack.
        /// </summary>
        /// <param name="stack">The stack.</param>
        /// <param name="output">The output.</param>
        /// <param name="op">The operator</param>
        private static void AddOperatorToStack(Stack<OperatorToken> stack, ICollection<Token> output, OperatorToken op)
        {
            if (op.Operator == OperatorType.RightBraket)//move from stack to output until left braket occurs
            {
                while (true)
                {
                    var token = stack.Pop();
                    if (token.Operator != OperatorType.LeftBraket)
                        output.Add(token);
                    else
                        break;
                }
            }
            else//move from stack output until less priority found or stack is empty
            {
                while (stack.Count > 0 && op.Operator != OperatorType.LeftBraket && stack.Peek().Priority >= op.Priority)
                {
                    var token = stack.Pop();
                    if (token.Operator != OperatorType.LeftBraket)
                        output.Add(token);
                    else
                        break;
                }
            }

            if (op.Operator != OperatorType.RightBraket)
                stack.Push(op);
        }

        /// <summary>
        /// Evaluates formula
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MathException">Formula is not valid, cannot evaluate it</exception>
        /// <exception cref="UnknownEnumException{TokenType}"></exception>
        public double Evaluate()
        {
            if (!IsValid)
                throw new MathException("Formula is not valid, cannot evaluate it");

            var stack = new Stack<double>();
            bool negateNextStatement = false;

            foreach (var token in Tokens)
            {
                switch (token.Type)
                {
                    case TokenType.Number:
                        stack.Push(negateNextStatement ? -((NumberToken)token).Number : ((NumberToken)token).Number);
                        negateNextStatement = false;
                        break;
                    case TokenType.Operator:
                        stack.Push(Compute(stack.Pop(), stack.Pop(), ((OperatorToken)token).Operator));
                        break;
                    case TokenType.Negation:
                        negateNextStatement = true;
                        break;
                    case TokenType.Variable:
                        //if (Adapter == null)
                        //{
                        //    //throw new FormulaParserException("No adapter given");
                        //    stack.Push(1.0);
                        //}
                        //else
                        //{
                        //    stack.Push(Adapter.GetValueForVariable(((VariableToken)token).Variable));
                        //}
                        break;
                    default:
                        throw new UnknownEnumException<TokenType>(token.Type);
                }
            }

            return stack.Pop();
        }

        /// <summary>
        /// Computes single RPN operation
        /// </summary>
        /// <param name="a">The first parameter</param>
        /// <param name="b">The second parameter</param>
        /// <param name="operatorType">Type of the operator.</param>
        /// <returns></returns>
        /// <exception cref="UnknownEnumException{OperatorType}"></exception>
        private double Compute(double a, double b, OperatorType operatorType)
        {
            switch (operatorType)
            {
                case OperatorType.Plus:
                    return b + a;
                case OperatorType.Minus:
                    return b - a;
                case OperatorType.Mult:
                    return b * a;
                case OperatorType.Div:
                    return b / a;
                default:
                    throw new UnknownEnumException<OperatorType>();
            }
        }
    }

    #region Enums
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

    /// <summary>
    /// Type of operator
    /// </summary>
    public enum OperatorType
    {
        /// <summary>
        /// The plus
        /// </summary>
        Plus,
        /// <summary>
        /// The minus
        /// </summary>
        Minus,
        /// <summary>
        /// The multiplication
        /// </summary>
        Mult,
        /// <summary>
        /// The division
        /// </summary>
        Div,
        /// <summary>
        /// The left braket
        /// </summary>
        LeftBraket,
        /// <summary>
        /// The right braket
        /// </summary>
        RightBraket
    }
    #endregion

    #region PrivateClasses
    /// <summary>
    /// The reverse polish notation token
    /// </summary>
    public abstract class Token
    {
        /// <summary>
        /// Gets the token type.
        /// </summary>
        public TokenType Type { get; protected set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var b = obj as Token;

            return b != null && this.Type == b.Type;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (int)Type;
        }
    }

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
    #endregion
}
