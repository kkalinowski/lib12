using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using lib12.Collections;
using lib12.FunctionalFlow;
using lib12.Misc;

namespace lib12.Data.Dummy
{
    public static class DummyClass
    {
        public static Random Random { get; set; }

        static DummyClass()
        {
            Random = new Random();
        }

        public static T Generate<T>(params PropertyGeneratorBase<T>[] propertyGenerationRules)
        {
            var propsGenerators = SetupGeneratorsForType(propertyGenerationRules);
            return GenerateValueUsingPropertyGenerators(propsGenerators);
        }

        public static T[] Generate<T>(int count, params PropertyGeneratorBase<T>[] propertyGenerationRules)
        {
            return Enumerable
                .Range(0, count)
                .Select(x => Generate(propertyGenerationRules))
                .ToArray();
        }

        private static List<PropertyGeneratorBase<T>> SetupGeneratorsForType<T>(params PropertyGeneratorBase<T>[] propertyGenerationRules)
        {
            var generatorDict = propertyGenerationRules.ToDictionary(x => x.PropertyName, x => x);
            var props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var propsGenerators = new List<PropertyGeneratorBase<T>>();
            foreach (var prop in props)
            {
                var setMethod = prop.GetSetMethod();
                if (setMethod == null || setMethod.IsPrivate)
                    continue;

                var explicitGenerator = generatorDict.GetValueOrDefault(prop.Name);
                if (explicitGenerator != null)
                    propsGenerators.Add(explicitGenerator);
                else
                    propsGenerators.Add(new GenericPropertyGenerator<T>(prop.Name, prop.PropertyType));
            }

            return propsGenerators;
        }

        private static T GenerateValueUsingPropertyGenerators<T>(List<PropertyGeneratorBase<T>> propsGenerators)
        {
            var item = Activator.CreateInstance<T>();
            propsGenerators.ForEach(x => x.GenerateProperty(item, Random));
            return item;
        }
    }
}
