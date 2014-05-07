using System;
using lib12.Extensions;

namespace lib12.Mathematics
{
    /// <summary>
    /// Quadratic equation computation
    /// </summary>
    public class QuadraticEquation
    {
        /// <summary>
        /// The A parameter
        /// </summary>
        public double A { get; private set; }
        /// <summary>
        /// The B parameter
        /// </summary>
        public double B { get; private set; }
        /// <summary>
        /// The C parameter
        /// </summary>
        public double C { get; private set; }

        /// <summary>
        /// The delta coefficent
        /// </summary>
        public double Delta { get; private set; }
        /// <summary>
        /// Type of result of equation
        /// </summary>
        public QuadraticEquationResultType ResultType { get; private set; }

        /// <summary>
        /// Gets the first result.
        /// </summary>
        public double FirstResult
        {
            get
            {
                if (ResultType.Is(QuadraticEquationResultType.NoResults))
                    throw new MathException("This equation has no results");
                else if (ResultType.Is(QuadraticEquationResultType.OneResult))
                    return -B / (2 * A);
                else
                    return (-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A);
            }
        }

        /// <summary>
        /// Gets the second result.
        /// </summary>
        public double SecondResult
        {
            get
            {
                if (ResultType.Is(QuadraticEquationResultType.NoResults))
                    throw new MathException("This equation has no results");
                else if (ResultType.Is(QuadraticEquationResultType.OneResult))
                    throw new MathException("This equation has only one result");
                else
                    return (-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuadraticEquation"/> class.
        /// </summary>
        /// <param name="a">The A parameter</param>
        /// <param name="a">The B parameter</param>
        /// <param name="a">The C parameter</param>
        public QuadraticEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;

            Delta = b * b - 4 * a * c;
            if (Delta > 0)
                ResultType = QuadraticEquationResultType.TwoResults;
            else if (Delta == 0)
                ResultType = QuadraticEquationResultType.OneResult;
            else
                ResultType = QuadraticEquationResultType.NoResults;
        }
    }
}