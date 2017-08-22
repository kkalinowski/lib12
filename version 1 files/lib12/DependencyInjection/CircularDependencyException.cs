using System;

namespace lib12.DependencyInjection
{
    public class CircularDependencyException : DependencyInjectionException
    {
        public CircularDependencyException(Type firstType, Type secondType)
            : base(string.Format("Types {0} and {1} depend on each other", firstType.Name, secondType.Name))
        {
        }
    }
}
