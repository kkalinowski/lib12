using System.Xml.Linq;
using lib12.Extensions;

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
            if(attribute.IsNull())
                throw new lib12Exception($"There is no attribute named {name}");

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