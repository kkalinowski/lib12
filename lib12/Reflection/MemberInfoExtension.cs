using System;
using System.Linq;
using System.Reflection;

namespace lib12.Reflection
{
    /// <summary>
    /// MemberInfoExtension
    /// </summary>
    public static class MemberInfoExtension
    {
        /// <summary>
        /// Gets the attribute decorating given member
        /// </summary>
        /// <param name="member">The member to check</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this MemberInfo member) where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();
            return (T)attribute;
        }

        /// <summary>
        /// Checks if member is marked with given attribute
        /// </summary>
        /// <param name="member">The member to check</param>
        /// <typeparam name="T">Type of attribute</typeparam>
        /// <returns></returns>
        public static bool IsMarkedWithAttribute<T>(this MemberInfo member) where T : Attribute
        {
            return Attribute.IsDefined(member, typeof(T));
        }
    }
}
