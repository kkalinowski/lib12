﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using lib12.Checking;
using lib12.Extensions;

namespace lib12.Reflection
{
    /// <summary>
    /// TypeExtension
    /// </summary>
    public static class TypeExtension
    {
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
        public static object GetPropertyValue(this Type type, object source, string propertyName)
        {
            if (propertyName.IsNullOrEmpty())
                throw new ArgumentException("Provided property name cannot be null or empty", propertyName);

            var prop = type.GetTypeInfo().GetDeclaredProperty(propertyName);
            if (prop == null)
                throw new lib12Exception(string.Format("Type {0} don't have property named {1}", type.Name, propertyName));

            return prop.GetValue(source, null);
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
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
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

            return interfaceType.IsAssignableFrom(type);
        }
    }
}
