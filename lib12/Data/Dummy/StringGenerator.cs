using System;
using System.Linq.Expressions;
using System.Reflection;

namespace lib12.Data.Dummy
{
    public class StringGenerator<T> : PropertyGenerator<T, string>
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public StringGenerator(Expression<Func<T, string>> selector, int minLength, int maxLength)
            : base(selector)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }

        public override void GenerateProperty(T item, Random random)
        {
            var prop = (PropertyInfo)((MemberExpression)Selector.Body).Member;
            var stringToSet = random.NextString(random.Next(MinLength, MaxLength));
            prop.SetValue(item, stringToSet, null);
        }
    }
}
