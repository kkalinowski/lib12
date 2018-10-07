using System.Xml.Linq;

namespace lib12.Data.Xml
{
    /// <summary>
    /// XmlExtensions
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Adds the child element
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static XElement AddChild(this XElement parent, string name)
        {
            var element = new XElement(name);
            parent.Add(element);

            return element;
        }

        /// <summary>
        /// Adds the attribute element
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static XElement AddAttribute(this XElement element, string name, object value)
        {
            var attribute = new XAttribute(name, value);
            element.Add(attribute);

            return element;
        }

        /// <summary>
        /// Sets the attribute value.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="lib12Exception"></exception>
        public static XElement SetAttributeValue(this XElement element, string name, object value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                throw new lib12Exception($"There is no attribute named {name}");

            attribute.SetValue(value);
            return element;
        }

        /// <summary>
        /// Removes all children from element
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns></returns>
        public static XElement RemoveAllChildren(this XElement parent)
        {
            parent.RemoveAll();
            return parent;
        }
    }
}