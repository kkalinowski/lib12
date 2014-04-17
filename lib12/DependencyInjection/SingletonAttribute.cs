using System;
using System.Diagnostics.Contracts;

namespace lib12.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SingletonAttribute : Attribute
    {
    }
}
