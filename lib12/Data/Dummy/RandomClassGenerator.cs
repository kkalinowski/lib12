using System;
using System.Collections.Generic;
using lib12.Collections;
using lib12.Core;

namespace lib12.Data.Dummy
{
    public class RandomClassGenerator
    {
        #region Fields
        private Random random;
        #endregion

        #region ctor
        public RandomClassGenerator()
        {
            random = new Random();
        }
        #endregion

        #region Logic
        public List<T> Generate<T>(int count, params PropertyGeneratorBase<T>[] propertyGenerationRules)
        {
            var list = new List<T>(count);
            TimesLoop.Do(count, () =>
            {
                var item = Activator.CreateInstance<T>();
                propertyGenerationRules.ForEach(x => x.GenerateProperty(item, random));

                list.Add(item);
            });

            return list;
        } 
        #endregion
    }
}
