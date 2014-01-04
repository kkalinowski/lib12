using System;

namespace lib12.Exceptions
{
    public class UnknownEnumException : lib12Exception
    {
        public UnknownEnumException(Type enumType) : base(string.Format("Unknown enum value in type {0}", enumType.Name))
        {
        }
    }
}
