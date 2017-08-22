using System;

namespace lib12.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class WireUpAttribute : Attribute
    {
    }
}
