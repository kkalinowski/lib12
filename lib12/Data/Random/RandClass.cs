using System;
using System.Linq;
using System.Reflection;
using lib12.Extensions;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public static partial class Rand
    {
        public static T Next<T>() where T : class
        {
            var item = Activator.CreateInstance<T>();
            SetProperties(typeof(T), item);
            return item;
        }

        public static T[] NextArrayOf<T>(int count) where T : class
        {
            return Enumerable
                .Range(0, count)
                .Select(x => Next<T>())
                .ToArray();
        }

        public static object Next(Type type)
        {
            var item = Activator.CreateInstance(type);
            SetProperties(type, item);
            return item;
        }

        private static void SetProperties(Type type, object item)
        {
            var props = type.GetTypeInfo().DeclaredProperties;
            foreach (var prop in props)
            {
                var setMethod = prop.SetMethod;
                if (setMethod == null || setMethod.IsPrivate)
                    continue;

                var value = GenerateValue(prop.PropertyType, prop.Name);
                item.SetProperty(prop.Name, value);
            }
        }

        private static object GenerateValue(Type propertyType, string propertyName)
        {
            if (propertyType.GetTypeInfo().IsEnum)
                return NextEnum(propertyType);
            else if (propertyType == typeof (string))
                return GenerateStringProperty(propertyName);
            else if (propertyType == typeof (int))
                return NextInt(1, 1000);
            else if (propertyType == typeof (double))
                return NextDouble(-1000, 1000);
            else if (propertyType == typeof (DateTime))
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
