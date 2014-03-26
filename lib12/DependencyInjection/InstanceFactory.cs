using System;
using System.Linq;
using lib12.Collections;
using lib12.Extensions;
using System.Collections.Generic;
using System.Reflection;
using lib12.Reflection;

namespace lib12.DependencyInjection
{
    public class InstanceFactory
    {
        #region Fields
        private readonly InstancesContainer container;
        private readonly Stack<Type> creationStack;
        private readonly List<LazyProperty> lazyProperties;
        #endregion

        #region ctor
        public InstanceFactory(InstancesContainer container)
        {
            this.container = container;
            creationStack = new Stack<Type>();
            lazyProperties = new List<LazyProperty>();
        }
        #endregion

        #region Create instance
        public object CreateInstance(TypeRegistration registration)
        {
            if (creationStack.Contains(registration.Type))
                throw new CircularDependencyException(registration.Type, creationStack.Peek());
            else
                creationStack.Push(registration.Type);

            var instance = CreateInstanceOfType(registration.Type);
            if (registration.WireUpAllProperties)
            {
                var propertiesToResolve = instance.GetType().GetProperties().Where(x => x.GetAttribute<DoNotWireUpAttribute>() == null);
                ResolveProperties(instance, propertiesToResolve);
            }

            creationStack.Pop();
            if (registration.IsSingleton)
                container.SingletonInstances.Add(registration.Type.AssemblyQualifiedName, instance);
            if (creationStack.IsEmpty())
                ResolveLazyProperties();
            return instance;
        }

        private object CreateInstanceOfType(Type type)
        {
            var ctors = type.GetConstructors();
            if (ctors.Length > 1)
                throw new DependencyInjectionException("Dependency inject classes can have only one constructor");

            var ctor = ctors.First();
            var parameters = ctor.GetParameters().Select(x => TryResolveCtorParam(type, x.ParameterType)).ToArray();
            var instance = ctor.Invoke(parameters);
            var propertiesToResolve = type.GetProperties().Where(x => x.GetAttribute<WireUpAttribute>() != null);
            ResolveProperties(instance, propertiesToResolve);
            return instance;
        }

        private void ResolveProperties(object instance, IEnumerable<PropertyInfo> properties)
        {
            object resolved;
            foreach (var property in properties)
            {
                TryResolveProperty(instance, property, out resolved);
                if (resolved != null)
                    property.SetValue(instance, resolved, null);
            }
        }

        private void ResolveLazyProperties()
        {
            foreach (var lazyProperty in lazyProperties)
            {
                lazyProperty.Property.SetValue(lazyProperty.Instance, container.Get(lazyProperty.Property.PropertyType), null);
            }
        }
        #endregion

        #region TryResolve
        private object TryResolveCtorParam(Type ctorType, Type paramType)
        {
            if (creationStack.Contains(paramType))
                throw new CircularDependencyException(ctorType, paramType);
            else
                return container.Get(paramType);
        }

        private void TryResolveProperty(object instance, PropertyInfo property, out object resolvedType)
        {
            if (creationStack.Contains(property.PropertyType))
            {
                lazyProperties.Add(new LazyProperty(instance, property));
                resolvedType = null;
            }
            else
            {
                resolvedType = container.Get(property.PropertyType);
            }
        }
        #endregion
    }
}
