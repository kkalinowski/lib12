using System;
using System.Linq;
using System.Reflection;
using lib12.Collections;
using lib12.Extensions;
using lib12.Reflection;
using ConstrainCollection = System.Collections.Generic.Dictionary<string, lib12.Data.Random.RandDataConstrain>;

namespace lib12.Data.Random
{
    public static partial class Rand
    {
        /// <summary>
        /// Returns a random object of given type
        /// </summary>
        /// <param name="type">The type to generate</param>
        /// <param name="constrains">The constrains for generating properties</param>
        /// <returns></returns>
        public static object Next(Type type, ConstrainCollection constrains = null)
        {
            var item = Activator.CreateInstance(type);
            SetProperties(type, item, constrains ?? new ConstrainCollection());
            return item;
        }

        /// <summary>
        /// Returns a random object of given type
        /// </summary>
        /// <typeparam name="T">The type to generate</typeparam>
        /// <param name="constrains">The constrains for generating properties</param>
        /// <returns></returns>
        public static T Next<T>(ConstrainCollection constrains = null) where T : class
        {
            var item = Activator.CreateInstance<T>();
            SetProperties(typeof(T), item, constrains ?? new ConstrainCollection());
            return item;
        }

        /// <summary>
        /// Returns an array of random objects of given type
        /// </summary>
        /// <typeparam name="T">The type to generate</typeparam>
        /// <param name="count">The count of objects to generate</param>
        /// <param name="constrains">The constrains for generating properties</param>
        /// <returns></returns>
        public static T[] NextArrayOf<T>(int count, ConstrainCollection constrains = null) where T : class
        {
            return CollectionFactory
                .CreateArray(count, i => Next<T>(constrains));
        }

        private static void SetProperties(Type type, object item, ConstrainCollection constrains)
        {
            var props = type.GetTypeInfo().DeclaredProperties;
            foreach (var prop in props)
            {
                var setMethod = prop.SetMethod;
                if (setMethod == null || setMethod.IsPrivate)
                    continue;

                var propertyConstrain = constrains.GetValueOrDefault(prop.Name);
                var value = GeneratePropertyValue(prop.PropertyType, prop.Name, propertyConstrain);
                item.SetProperty(prop.Name, value);
            }
        }

        private static object GeneratePropertyValue(Type type, string name, RandDataConstrain constrain)
        {
            switch (constrain)
            {
                case ValueSetConstrain valueSetConstrain:
                    return GenerateRandValueFromSetConstrain(valueSetConstrain);
                case IntConstrain intConstrain:
                    return GenerateRandValueFromIntConstrain(intConstrain);
                case DoubleConstrain doubleConstrain:
                    return GenerateRandValueFromDoubleConstrain(doubleConstrain);
                case FactoryMethodConstrain factoryMethodConstrain:
                    return GenerateRandValueFromFactoryMethodConstrain(factoryMethodConstrain);
                default:
                    return GenerateRandValueWithoutConstrain(type, name);
            }
        }

        private static object GenerateRandValueFromSetConstrain(ValueSetConstrain valuesConstrain)
        {
            return valuesConstrain.AvailableValues
                .Cast<object>()
                .GetRandomItem();
        }

        private static object GenerateRandValueFromIntConstrain(IntConstrain intConstrain)
        {
            return NextInt(intConstrain.MinValue, intConstrain.MaxValue);
        }

        private static object GenerateRandValueFromDoubleConstrain(DoubleConstrain doubleConstrain)
        {
            return NextDouble(doubleConstrain.MinValue, doubleConstrain.MaxValue);
        }

        private static object GenerateRandValueFromFactoryMethodConstrain(FactoryMethodConstrain factoryMethodConstrain)
        {
            return factoryMethodConstrain.FactoryMethod();
        }

        private static object GenerateRandValueWithoutConstrain(Type propertyType, string propertyName)
        {
            if (propertyType.GetTypeInfo().IsEnum)
                return NextEnum(propertyType);
            else if (propertyType == typeof(string))
                return GenerateStringProperty(propertyName);
            else if (propertyType == typeof(int))
                return NextInt(1, 1000);
            else if (propertyType == typeof(double))
                return NextDouble(-1000, 1000);
            else if (propertyType == typeof(DateTime))
                return NextDateTime(DateTime.Now.AddYears(-10), DateTime.Now);
            else if (propertyType.GetTypeInfo().IsClass)
                return Next(propertyType);
            else
                return propertyType.GetDefault();
        }

        private static string GenerateStringProperty(string propertyName)
        {
            if (propertyName.EqualsIgnoreCase("Name"))
                return NextName();
            else if (propertyName.EqualsIgnoreCase("MaleName"))
                return NextMaleName();
            else if (propertyName.EqualsIgnoreCase("FemaleName"))
                return NextFemaleName();
            else if (propertyName.EqualsIgnoreCase("Surname"))
                return NextSurname();
            else if (propertyName.EqualsIgnoreCase("Email"))
                return NextEmail();
            else if (propertyName.EqualsIgnoreCase("FullName"))
                return NextFullName();
            else if (propertyName.EqualsIgnoreCase("Country"))
                return NextCountry();
            else if (propertyName.EqualsIgnoreCase("City"))
                return NextCity();
            else if (propertyName.EqualsIgnoreCase("Address"))
                return NextAddress();
            else if (propertyName.EqualsIgnoreCase("ZipCode"))
                return NextZipCode();
            else if (propertyName.EqualsIgnoreCase("Company"))
                return NextCompany();
            else
                return NextString();
        }
    }
}
