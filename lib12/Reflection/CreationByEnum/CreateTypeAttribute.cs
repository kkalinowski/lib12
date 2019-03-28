using System;

namespace lib12.Reflection.CreationByEnum
{
    /// <summary>
    /// Describes which type is associated with enum
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CreateTypeAttribute : Attribute
    {
        #region Props
        /// <summary>
        /// Gets or sets the type to create
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; set; }
        #endregion Props

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTypeAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CreateTypeAttribute(Type type)
        {
            Type = type;
        }
        #endregion ctor
    }
}
