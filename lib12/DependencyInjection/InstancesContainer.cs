using System;
using System.Collections.Generic;
using System.Linq;
using lib12.Collections;

namespace lib12.DependencyInjection
{
    public class InstancesContainer
    {
        #region Fields
        private readonly InstanceFactory instanceFactory;
        #endregion

        #region Props
        public Dictionary<string, TypeRegistration> RegisteredTypes { get; private set; }
        public Dictionary<string, object> SingletonInstances { get; private set; }
        #endregion

        #region ctor
        public InstancesContainer()
        {
            instanceFactory = new InstanceFactory(this);
            RegisteredTypes = new Dictionary<string, TypeRegistration>();
            SingletonInstances = new Dictionary<string, object>();
        }
        #endregion

        #region Manual registration
        public void RegisterSingleton<T>(string key = null)
        {
            RegisterTypeManual(typeof(T), true, false, key);
        }

        public void RegisterSingleton<TContract, TService>(string key = null)
        {
            RegisterTypeManual(typeof(TContract), true, false, key, typeof(TService));
        }

        public void RegisterTransient<T>(string key = null)
        {
            RegisterTypeManual(typeof(T), false, false, key);
        }

        public void RegisterTransient<TContract, TService>(string key = null)
        {
            RegisterTypeManual(typeof(TContract), true, false, key, typeof(TService));
        }

        private void RegisterTypeManual(Type type, bool isSingleton, bool wireUpAllProperties, string key = null, Type withService = null)
        {
            var typeDecoration = AttributesHelper.GetTypeDecoration(type);
            if(typeDecoration.IsSingleton || typeDecoration.IsTransient)
                throw new DependencyInjectionException(string.Format("Type {0} is already registered by attribute", type.AssemblyQualifiedName));

            var registrationKey = key ?? type.AssemblyQualifiedName;
            if (RegisteredTypes.ContainsKey(registrationKey))
                throw new DependencyInjectionException(string.Format("Type {0} is already registered with key {1}", type.AssemblyQualifiedName, registrationKey));

            var registration = new TypeRegistration(type, isSingleton, wireUpAllProperties, withService);
            RegisteredTypes.Add(registrationKey, registration);
        }
        #endregion

        #region Get
        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        public object Get(Type type)
        {
            var registration = GetRegistration(type);
            if (registration.IsSingleton)
                return GetSingletonInstance(registration);
            else
                return GetTransientInstance(registration);
        }

        public object Get(string key)
        {
            var instance = SingletonInstances.GetValueOrDefault(key);
            if (instance == null)
            {
                var registration = GetRegistration(key);
                return GetSingletonInstance(registration);
            }
            else
                return instance;
        }

        private object GetSingletonInstance(TypeRegistration registration)
        {
            var instance = SingletonInstances.GetValueOrDefault(registration.Type.AssemblyQualifiedName);
            if (instance == null)
            {
                instance = instanceFactory.CreateInstance(registration);
            }

            return instance;
        }

        private object GetTransientInstance(TypeRegistration registration)
        {
            return instanceFactory.CreateInstance(registration);
        }
        #endregion

        #region TypeRegistration
        private TypeRegistration GetRegistration(Type type)
        {
            var registration = RegisteredTypes.GetValueOrDefault(type.AssemblyQualifiedName);
            if (registration == null)
            {
                registration = CreateTypeRegistration(type);
                RegisteredTypes.Add(type.AssemblyQualifiedName, registration);
            }

            return registration;
        }

        private TypeRegistration GetRegistration(string typeName)
        {
            var registration = RegisteredTypes.GetValueOrDefault(typeName);
            if (registration == null)
            {
                var type = Type.GetType(typeName);
                registration = CreateTypeRegistration(type);
                RegisteredTypes.Add(typeName, registration);
            }

            return registration;
        }

        private TypeRegistration CreateTypeRegistration(Type type)
        {
            var typeDecoration = AttributesHelper.GetTypeDecoration(type);
            if (!typeDecoration.IsSingleton && !typeDecoration.IsTransient)
                throw new NotRegisteredTypeException(type);
            else if (typeDecoration.IsSingleton && typeDecoration.IsTransient)
                throw new DependencyInjectionException(string.Format("Type {0} was registered as singleton and transient", type.AssemblyQualifiedName));

            return new TypeRegistration
            {
                Type = type,
                IsSingleton = typeDecoration.IsSingleton,
                WireUpAllProperties = typeDecoration.WireUpAllProperties
            };
        }
        #endregion
    }
}
