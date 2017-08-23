
namespace lib12.Misc
{
    public class UnknownEnumException<TEnum> : lib12Exception
    {
        public UnknownEnumException(TEnum value)
            : base(string.Format("Unknown enum value {0} of type {1}", value.ToString(), value.GetType().Name))
        {
        }

        public UnknownEnumException()
            : base(string.Format("Unknown enum value of type {0}", typeof(TEnum).Name))
        {
        }
    }
}
