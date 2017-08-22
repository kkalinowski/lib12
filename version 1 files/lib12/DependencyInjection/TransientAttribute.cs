using System;

namespace lib12.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TransientAttribute : Attribute
    {
    }
}
