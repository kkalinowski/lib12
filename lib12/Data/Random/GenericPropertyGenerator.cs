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

        public override void GenerateProperty(T item, System.Random random)
        {
            var value = GenerateValue(random);
            item.SetProperty(PropertyName, value);
        }

        private object GenerateValue(System.Random random)
        {
            if (propertyType == typeof(string))
                return GenerateStringProperty(random);
            else if (propertyType == typeof(int))
                return random.Next(1, 1000);
            else if (propertyType == typeof(double))
                return random.NextDouble();
            else if (propertyType == typeof(DateTime))
                return random.NextDateTime(DateTime.Now.AddYears(-10), DateTime.Now);
            else
                return propertyType.GetDefault();
        }

        private string GenerateStringProperty(System.Random random)
        {
            if (propertyName.EqualsIgnoreCase("Name"))
                return random.NextName();
            else if (propertyName.EqualsIgnoreCase("MaleName"))
                return random.NextMaleName();
            else if (propertyName.EqualsIgnoreCase("FemaleName"))
                return random.NextFemaleName();
            else if (propertyName.EqualsIgnoreCase("Surname"))
                return random.NextSurname();
            else if (propertyName.EqualsIgnoreCase("Email"))
                return random.NextEmail();
            else if (propertyName.EqualsIgnoreCase("FullName"))
                return random.NextFullName();
            else if (propertyName.EqualsIgnoreCase("Country"))
                return random.NextCountry();
            else if (propertyName.EqualsIgnoreCase("City"))
                return random.NextCity();
            else if (propertyName.EqualsIgnoreCase("Address"))
                return random.NextAddress();
            else if (propertyName.EqualsIgnoreCase("ZipCode"))
                return random.NextZipCode();
            else if (propertyName.EqualsIgnoreCase("Company"))
                return random.NextCompany();
            else
                return random.NextString();
        }
    }
}