using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace lib12.Data.Random
{
    public class EnumGenerator<T, TEnum> : PropertyGenerator<T, TEnum>
    {
        #region Fields
        private TEnum[] enumValues;
        #endregion

        #region ctor
        public EnumGenerator(Expression<Func<T, TEnum>> selector)
            : base(selector)
        {
            enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        }
        #endregion

        #region Generate
        public override void GenerateProperty(T item, System.Random random)
        {
            var prop = (PropertyInfo)((MemberExpression)Selector.Body).Member;
            var enumToSet = enumValues[random.Next(enumValues.Length)];
            prop.SetValue(item, enumToSet, null);
        } 
        #endregion
    }
}