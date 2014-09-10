using System;
using lib12.Extensions;
using lib12.Reflection;

namespace lib12.Data.Dummy
{
    public class GenericPropertyGenerator<T> : PropertyGeneratorBase<T>
    {
        private readonly string propertyName;
        private readonly Type propertyType;
        private readonly Random random;

        public override string PropertyName { get { return propertyName; } }

        public GenericPropertyGenerator(string propertyName, Type propertyType, Random random)
        {
            this.propertyName = propertyName;
            this.propertyType = propertyType;
            this.random = random;
        }

        public override void GenerateProperty(T item, Random random)
        {
            var value = GenerateValue();
            item.SetProperty(PropertyName, value);
        }

        private object GenerateValue()
        {
            if (propertyType == typeof(string))
                return GenerateStringProperty();
            else if (propertyType == typeof(int))
                return random.Next(1, 1000);
            else if (propertyType == typeof(double))
                return random.NextDouble();
            else if (propertyType == typeof(DateTime))
                return random.NextDateTime(DateTime.Now.AddYears(-10), DateTime.Now);
            else
                return propertyType.GetDefault();
        }

        private string GenerateStringProperty()
        {
            if (propertyName.EqualsUnCased("Name"))
                return random.NextName();
            else if (propertyName.EqualsUnCased("MaleName"))
                return random.NextMaleName();
            else if (propertyName.EqualsUnCased("FemaleName"))
                return random.NextFemaleName();
            else if (propertyName.EqualsUnCased("Surname"))
                return random.NextSurname();
            else if (propertyName.EqualsUnCased("FullName"))
                return random.NextFullName();
            else if (propertyName.EqualsUnCased("Country"))
                return random.NextCountry();
            else if (propertyName.EqualsUnCased("City"))
                return random.NextCity();
            else if (propertyName.EqualsUnCased("Address"))
                return random.NextAddress();
            else if (propertyName.EqualsUnCased("ZipCode"))
                return random.NextZipCode();
            else if (propertyName.EqualsUnCased("Company"))
                return random.NextCompany();
            else
                return random.NextString();
        }
    }
}