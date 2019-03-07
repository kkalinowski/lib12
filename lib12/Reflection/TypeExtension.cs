using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using lib12.Checking;
using lib12.Collections;
using lib12.Extensions;

namespace lib12.Reflection
{
    /// <summary>
    /// TypeExtension
    /// </summary>
    public static class TypeExtension
    {
        private const string BackingFieldSuffix = "k__BackingField";

        /// <summary>
        /// Determines whether the specified type is numeric or nullable numeric
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns></returns>
        [Obsolete("Use IsNumberOrNullableNumber instead")]
        public static bool IsTypeNumericOrNullableNumeric(this Type type)
        {
            return type.IsTypeNumeric() || type.IsNullable() && Nullable.GetUnderlyingType(type).IsTypeNumeric();
        }

        /// <summary>
        /// Determines whether the specified type is number or nullable number
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns></returns>
        public static bool IsNumberOrNullableNumber(this Type type)
        {
            return type.IsNumber() || type.IsNullable() && Nullable.GetUnderlyingType(type).IsNumber();
        }

        /// <summary>
        /// Determines whether the specified type is numeric
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns></returns>
        [Obsolete("Use IsNumber instead")]
        public static bool IsTypeNumeric(this Type type)
        {
            return type.GetTypeInfo().IsPrimitive || type.FullName == "System.Decimal";
        }

        /// <summary>
        /// Determines whether the specified type is number.
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>
        ///   <c>true</c> if the specified type is number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumber(this Type type)
        {
            return type.IsIntegralNumber() || type.IsFloatingPointNumber();
        }

        /// <summary>
        /// Determines whether the specified type is integral number.
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>
        ///   <c>true</c> if [is integral number] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsIntegralNumber(this Type type)
        {
            return Type.GetTypeCode(type)
                .IsAnyOf(TypeCode.Byte, TypeCode.SByte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64);
        }

        /// <summary>
        /// Determines whether the specified type is floating point number.
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>
        ///   <c>true</c> if [is floating point number] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFloatingPointNumber(this Type type)
        {
            return Type.GetTypeCode(type)
                .IsAnyOf(TypeCode.Decimal, TypeCode.Double, TypeCode.Single);
        }

        /// <summary>
        /// Determines whether the specified type nullable
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Determines whether the specified type is static
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns></returns>
        public static bool IsStatic(this Type type)
        {
            //according to https://stackoverflow.com/questions/1175888/determine-if-a-type-is-static
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsAbstract && typeInfo.IsSealed;
        }

        /// <summary>
        /// Gets the attribute decorating given type
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <typeparam name="T">Type of attribute</typeparam>
        /// <returns></returns>
        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            var attribute = type.GetTypeInfo().GetCustomAttributes(typeof(T), false).SingleOrDefault();
            return (T)attribute;
        }

        /// <summary>
        /// Checks if member is marked with given attribute
        /// </summary>
        /// <param name="type">The type to check for attribute</param>
        /// <typeparam name="T">Type of attribute</typeparam>
        /// <returns></returns>
        public static bool IsMarkedWithAttribute<T>(this Type type) where T : Attribute
        {
            return Attribute.IsDefined(type, typeof(T));
        }

        /// <summary>
        /// Gets the default of given type
        /// </summary>
        /// <param name="type">The type to operate</param>
        /// <returns></returns>
        public static object GetDefault(this Type type)
        {
            if (type.GetTypeInfo().IsValueType)
                return Activator.CreateInstance(type);
            else
                return null;
        }

        /// <summary>
        /// Gets the default, parameterless constructor of given type or null if this not exists
        /// </summary>
        /// <param name="type">The type to operate</param>
        /// <returns></returns>
        public static ConstructorInfo GetDefaultConstructor(this Type type)
        {
            return type.GetTypeInfo().GetConstructor(Type.EmptyTypes);
        }

        /// <summary>
        /// Gets the property value
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to get value from</param>
        /// <param name="propertyName">Name of the property to get value from</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Provided property name cannot be null or empty</exception>
        /// <exception cref="lib12Exception"></exception>
        [Obsolete("Renamed to GetPropertyValueByName")]
        public static object GetPropertyValue(this Type type, object source, string propertyName)
        {
            if (propertyName.IsNullOrEmpty())
                throw new ArgumentException("Provided property name cannot be null or empty", propertyName);

            var prop = type.GetTypeInfo().GetDeclaredProperty(propertyName);
            if (prop == null)
                throw new lib12Exception($"Type {type.Name} don't have property named {propertyName}");

            return prop.GetValue(source, null);
        }

        /// <summary>
        /// Gets the value of property with given name
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to get value from</param>
        /// <param name="propertyName">Name of the property to get value from</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Provided property name and source object cannot be null or empty</exception>
        /// <exception cref="lib12Exception"></exception>
        public static object GetPropertyValueByName(this Type type, object source, string propertyName)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (propertyName.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(propertyName));

            var prop = type.GetProperty(propertyName);
            if (prop == null)
                throw new lib12Exception($"Type {type.Name} don't have property named {propertyName}");

            return prop.GetValue(source, null);
        }

        /// <summary>
        /// Sets the value of property with given name
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to set property value on</param>
        /// <param name="propertyName">Name of the property to set value</param>
        /// <param name="value">Value to set</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Provided property name and source object cannot be null or empty</exception>
        /// <exception cref="lib12Exception"></exception>
        public static void SetPropertyValueByName(this Type type, object source, string propertyName, object value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (propertyName.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(propertyName));

            var prop = type.GetProperty(propertyName);
            if (prop == null)
                throw new lib12Exception($"Type {type.Name} don't have property named {propertyName}");

            prop.SetValue(source, value, null);
        }

        /// <summary>
        /// Gets all properties values from type. Returns dictionary in the form of property name - value. If source object is null returns empty dictionary
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to get properties values from</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        public static Dictionary<string, object> GetPropertiesValues(this Type type, object source)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (source == null)
                return Empty.Dictionary<string, object>();

            return type
                .GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(source, null));
        }

        /// <summary>
        /// Gets the value of field with given name
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to get value from</param>
        /// <param name="fieldName">Name of the field to get value from</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Provided field name and source object cannot be null or empty</exception>
        /// <exception cref="lib12Exception"></exception>
        public static object GetFieldValueByName(this Type type, object source, string fieldName)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (fieldName.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(fieldName));

            var field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (field == null)
                throw new lib12Exception($"Type {type.Name} don't have field named {fieldName}");

            return field.GetValue(source);
        }

        /// <summary>
        /// Sets the value of field with given name
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to set field value on</param>
        /// <param name="fieldName">Name of the field to set value</param>
        /// <param name="value">Value to set</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Provided field name and source object cannot be null or empty</exception>
        /// <exception cref="lib12Exception"></exception>
        public static void SetFieldValueByName(this Type type, object source, string fieldName, object value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (fieldName.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(fieldName));

            var prop = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (prop == null)
                throw new lib12Exception($"Type {type.Name} don't have field named {fieldName}");

            prop.SetValue(source, value);
        }

        /// <summary>
        /// Gets all fields values from type. Returns dictionary in the form of field name - value. If source object is null returns empty dictionary
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to get fields values from</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        public static Dictionary<string, object> GetFieldsValues(this Type type, object source)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (source == null)
                return Empty.Dictionary<string, object>();

            return type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(x => !x.Name.EndsWith(BackingFieldSuffix))
                .ToDictionary(x => x.Name, x => x.GetValue(source));
        }

        /// <summary>
        /// Gets all constants from type
        /// </summary>
        /// <param name="type">The source type</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        public static FieldInfo[] GetConstants(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            return fieldInfos
                .Where(x => x.IsLiteral && !x.IsInitOnly)
                .ToArray();
        }

        /// <summary>
        /// Gets all constants values from type. Returns dictionary in the form of constant name - value
        /// </summary>
        /// <param name="type">The source type</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        public static Dictionary<string, object> GetConstantValues(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type
                .GetConstants()
                .ToDictionary(x => x.Name, x => x.GetRawConstantValue());
        }

        /// <summary>
        /// Returns constant value of given type by name. Throws exception if type doesn't contain constant with given name.
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="constantName">Constant name</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        /// <exception cref="lib12Exception">Constant with given name doesn't exists</exception>
        public static object GetConstantValueByName(this Type type, string constantName)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var constantField = type.GetField(constantName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (constantField == null)
                throw new lib12Exception($"Cannot find constant named {constantName}");

            return constantField.GetRawConstantValue();
        }

        /// <summary>
        /// Gets all constants, fields and properties values from type. Returns dictionary in the form of field name - value. If source object is null returns empty dictionary
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to get fields values from</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        public static Dictionary<string, object> GetAllObjectData(this Type type, object source)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (source == null)
                return Empty.Dictionary<string, object>();

            return type
                .GetConstantValues()
                .Concat(type.GetFieldsValues(source))
                .Concat(type.GetPropertiesValues(source));
        }

        /// <summary>
        /// Creates instance of class given its type
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="args">Arguments passed to type constructor</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        public static T CreateInstance<T>(this Type type, params object[] args)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (type != typeof(T))
                throw new lib12Exception("Given type is not the same as target type");

            return (T)Activator.CreateInstance(type, args);
        }

        /// <summary>
        /// Checks if given types implements target interface
        /// </summary>        
        /// <param name="type">The source type</param>
        /// <typeparam name="TInterface">Target interface to check for implementation</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        public static bool IsImplementingInterface<TInterface>(this Type type) where TInterface : class
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var interfaceType = typeof(TInterface);
            return IsImplementingInterface(type, interfaceType);
        }

        /// <summary>
        /// Checks if given types implements target interface
        /// </summary>        
        /// <param name="type">The source type</param>
        /// <param name="interfaceType">Target interface to check for implementation</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Source type is null</exception>
        public static bool IsImplementingInterface(this Type type, Type interfaceType)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (interfaceType == null)
                throw new ArgumentNullException(nameof(interfaceType));

            if (!interfaceType.IsInterface)
                throw new lib12Exception($"{interfaceType.FullName} is not an interface");

            if (type == interfaceType)
                throw new lib12Exception("Given type is the same as interface you are checking");

            if (interfaceType.IsGenericTypeDefinition)
                return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
            else
                return interfaceType.IsAssignableFrom(type);
        }

        /// <summary>
        /// Calls the method with given name
        /// </summary>
        /// <param name="type">The source type</param>
        /// <param name="source">The source object to call method on</param>
        /// <param name="methodName">Name of the method to call</param>
        /// <param name="args">List of arguments to pass to method</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Provided method name and source object cannot be null or empty</exception>
        /// <exception cref="lib12Exception"></exception>
        public static object CallMethodByName(this Type type, object source, string methodName, params object[] args)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (methodName.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(methodName));

            var method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            if (method == null)
                throw new lib12Exception($"Type {type.Name} don't have method named {methodName}");

            return method.Invoke(source, args);
        }
    }
}
