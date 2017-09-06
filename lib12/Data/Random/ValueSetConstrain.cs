using System.Collections;

namespace lib12.Data.Random
{
    public class ValueSetConstrain: RandDataConstrain
    {
        public IEnumerable AvailableValues { get; set; }
    }
}