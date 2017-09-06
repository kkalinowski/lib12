using System.Collections.Generic;

namespace lib12.Data.Random
{
    public class ValueSetConstrain<TKey> : RandDataConstrain
    {
        public IEnumerable<TKey> AvailableValues { get; set; }
    }
}