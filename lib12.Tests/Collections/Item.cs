namespace lib12.Tests.Collections
{
    public class Item
    {
        public int Value { get; set; }

        protected bool Equals(Item other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}