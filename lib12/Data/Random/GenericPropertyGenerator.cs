using System;
using lib12.Extensions;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public class GenericPropertyGenerator<T> : PropertyGeneratorBase<T>
    {
        private readonly string propertyName;
        private readonly Type propertyType;

        public override string PropertyName { get { return propertyName; } }

        public GenericPropertyGenerator(string propertyName, Type propertyType)
        {
            this.propertyName = propertyName;
            this.propertyType = propertyType;
        }

        public override void GenerateProperty(T item)
        {
            var value = GenerateValue();
            item.SetProperty(PropertyName, value);
        }

        private object GenerateValue()
        {
            if (propertyType == typeof(string))
                return GenerateStringProperty();
            else if (propertyType == typeof(int))
                return Rand.NextInt(1, 1000);
            else if (propertyType == typeof(double))
                return Rand.NextDouble(-1000, 1000);
            else if (propertyType == typeof(DateTime))
                return Rand.NextDateTime(DateTime.Now.AddYears(-10), DateTime.Now);
            else
                return propertyType.GetDefault();
        }

        private string GenerateStringProperty()
        {
            if (propertyName.EqualsIgnoreCase("Name"))
                return Rand.NextName();
            else if (propertyName.EqualsIgnoreCase("MaleName"))
                return Rand.NextMaleName();
            else if (propertyName.EqualsIgnoreCase("FemaleName"))
                return Rand.NextFemaleName();
            else if (propertyName.EqualsIgnoreCase("Surname"))
                return Rand.NextSurname();
            else if (propertyName.EqualsIgnoreCase("Email"))
                return Rand.NextEmail();
            else if (propertyName.EqualsIgnoreCase("FullName"))
                return Rand.NextFullName();
            else if (propertyName.EqualsIgnoreCase("Country"))
                return Rand.NextCountry();
            else if (propertyName.EqualsIgnoreCase("City"))
                return Rand.NextCity();
            else if (propertyName.EqualsIgnoreCase("Address"))
                return Rand.NextAddress();
            else if (propertyName.EqualsIgnoreCase("ZipCode"))
                return Rand.NextZipCode();
            else if (propertyName.EqualsIgnoreCase("Company"))
                return Rand.NextCompany();
            else
                return Rand.NextString();
        }
    }
}