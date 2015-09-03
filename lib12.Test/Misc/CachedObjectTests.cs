using System.Collections.Generic;
using lib12.Collections;
using lib12.Misc;
using Should;
using Xunit;

namespace lib12.Test.Misc
{
    public class CachedObjectTests
    {
        private const string Key = "key";
        private const string Value = "value";

        [Fact]
        public void cachedobject_is_working_with_dict()
        {
            var dict = new Dictionary<string, string>();
            var cachedObject = new CachedObject<string>(() => dict.Add(Key, Value), () => dict.GetValueOrDefault(Key));
            
            dict.Count.ShouldEqual(0);
            cachedObject.Get().ShouldEqual(Value);
            dict.Count.ShouldEqual(1);

            cachedObject.Get().ShouldEqual(Value);
            dict.Count.ShouldEqual(1);
        }
    }
}