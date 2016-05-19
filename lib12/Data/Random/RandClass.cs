using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using lib12.Collections;

namespace lib12.Data.Random
{
    public static partial class Rand
    {
        public static T Next<T>(params PropertyGeneratorBase<T>[] propertyGenerationRules)
        {
            var propsGenerators = SetupGeneratorsForType(propertyGenerationRules);
            return GenerateValueUsingPropertyGenerators(propsGenerators);
        }

        public static T[] NextArrayOf<T>(int count, params PropertyGeneratorBase<T>[] propertyGenerationRules)
        {
            return Enumerable
                .Range(0, count)
                .Select(x => Next(propertyGenerationRules))
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
            propsGenerators.ForEach(x => x.GenerateProperty(item));
            return item;
        }
    }
}
