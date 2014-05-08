using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using lib12.Collections;
using lib12.Exceptions;
using lib12.Extensions;

namespace lib12.Mathematics
{
    public class Formula
    {
        public string Text { get; private set; }
        public List<Token> Tokens { get; private set; }
        public bool IsValid { get; private set; }

        public Formula(string text)
        {
            Text = text;
            Tokens = Parse(Text);
        }

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
                        output.Add(Token.CreateNegationToken());
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

            IsValid = true;
            return output;
        }

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
    public enum TokenType
    {
        Number,
        Operator,
        Negation,
        Variable
    }

    public enum OperatorType
    {
        Plus,
        Minus,
        Mult,
        Div,
        LeftBraket,
        RightBraket
    }
    #endregion

    #region PrivateClasses
    public class Token
    {
        public TokenType Type { get; set; }

        public static Token CreateNegationToken()
        {
            return new Token() { Type = TokenType.Negation };
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            var b = obj as Token;

            return b != null && this.Type == b.Type;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (int)Type;
        }
    }

    public class NumberToken : Token
    {
        public double Number { get; set; }

        public NumberToken(double number)
        {
            Number = number;
            Type = TokenType.Number;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            var b = obj as NumberToken;

            return b != null && this.Number == b.Number;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (int)Number + (int)Type;
        }
    }

    public class OperatorToken : Token
    {
        public OperatorType Operator { get; set; }
        public int Priority { get; private set; }

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

        // override object.Equals
        public override bool Equals(object obj)
        {
            var b = obj as OperatorToken;

            return b != null && this.Operator == b.Operator;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (int)Operator + (int)Type;
        }
    }

    public class VariableToken : Token
    {
        public string Variable { get; set; }

        public VariableToken(string variable)
        {
            Variable = variable;
            Type = TokenType.Variable;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            var b = obj as VariableToken;

            return b != null && this.Variable == b.Variable;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Variable.GetHashCode() + (int)Type;
        }
    }
    #endregion
}
