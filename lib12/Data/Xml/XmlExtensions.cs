using System.Xml.Linq;
using lib12.FunctionalFlow;

namespace lib12.Data.Xml
{
    public static class XmlExtensions
    {
        public static XElement AddChild(this XElement parent, string name)
        {
            var element = new XElement(name);
            parent.Add(element);

            return element;
        }

        public static XElement AddAttribute(this XElement element, string name, object value)
        {
            var attribute = new XAttribute(name, value);
            element.Add(attribute);

            return element;
        }

        public static XElement SetAttributeValue(this XElement element, string name, object value)
        {
            var attribute = element.Attribute(name);
            attribute.ThrowExceptionIfNull();

            attribute.SetValue(value);
            return element;
        }

        public static XElement RemoveAllChildren(this XElement parent)
        {
            parent.RemoveAll();
            return parent;
        }
    }
}