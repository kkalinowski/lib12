using System;
using System.Collections.Generic;
using System.Linq;
using lib12.Collections;
using lib12.Misc;

namespace lib12.Data.Dummy
{
    public class RandomClassGenerator
    {
        #region Fields
        private readonly Random random;
        #endregion

        #region ctor
        public RandomClassGenerator(Random random = null)
        {
            this.random = random ?? new Random();
        }
        #endregion

        #region Logic
        public List<T> Generate<T>(int count, params PropertyGeneratorBase<T>[] propertyGenerationRules)
        {
            var propsGenerators = SetupGeneratorsForType(propertyGenerationRules);
            return GenerateValueUsingPropertyGenerators(count, propsGenerators);
        }

        private List<PropertyGeneratorBase<T>> SetupGeneratorsForType<T>(params PropertyGeneratorBase<T>[] propertyGenerationRules)
        {
            var generatorDict = propertyGenerationRules.ToDictionary(x => x.PropertyName, x => x);
            var props = typeof (T).GetProperties();
            var propsGenerators = new List<PropertyGeneratorBase<T>>();
            foreach (var prop in props)
            {
                var explicitGenerator = generatorDict.GetValueOrDefault(prop.Name);
                if (explicitGenerator != null)
                    propsGenerators.Add(explicitGenerator);
                else
                    propsGenerators.Add(new GenericPropertyGenerator<T>(prop.Name, prop.PropertyType));
            }

            return propsGenerators;
        }

        private List<T> GenerateValueUsingPropertyGenerators<T>(int count, List<PropertyGeneratorBase<T>> propsGenerators)
        {
            var list = new List<T>(count);
            TimesLoop.Do(count, () =>
            {
                var item = Activator.CreateInstance<T>();
                propsGenerators.ForEach(x => x.GenerateProperty(item, random));

                list.Add(item);
            });

            return list;
        }
        #endregion
    }
}
