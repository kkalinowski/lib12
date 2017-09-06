using System.Collections.Generic;

namespace lib12.Data.Random
{
    public class ValueSetConstrain<TKey> : RandConstrain
    {
        public IEnumerable<TKey> AvailableValues { get; set; }
    }
}