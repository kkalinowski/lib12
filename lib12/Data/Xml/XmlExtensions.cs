using System.Xml.Linq;

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
    }
}