using System;
using System.Linq.Expressions;
using System.Reflection;

namespace lib12.Reflection
{
    /// <summary>
    /// Extension methods for Expression class
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// Gets the name of property using in expression.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static string GetName<TSource, TValue>(this Expression<Func<TSource, TValue>> expression)
        {
            //http://stackoverflow.com/a/2916344/578560
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                var unaryBody = (UnaryExpression)expression.Body;
                body = unaryBody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }

        /// <summary>
        /// Gets the value of given expression for source
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="source">The source of value.</param>
        /// <returns></returns>
        public static TValue GetValue<TSource, TValue>(this Expression<Func<TSource, TValue>> expression, TSource source)
        {
            return expression.Compile()(source);
        }

        /// <summary>
        /// Sets the value for given expression
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        public static void SetValue<TSource, TValue>(this Expression<Func<TSource, TValue>> expression, TSource source, TValue value)
        {
            var prop = (PropertyInfo)((MemberExpression)expression.Body).Member;
            prop.SetValue(source, value, null);
        }
    }
}