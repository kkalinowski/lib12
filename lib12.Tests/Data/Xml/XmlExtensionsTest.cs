using System.IO;
using Xunit;

namespace lib12.Tests.Data.Xml
{
    public class XmlExtensionsTests
    {
        private readonly string sampleXml = File.ReadAllText("_Files/Sample.xml");

        [Fact]
        public void AddChild_CorrectInformation_CorrectResult()
        {
            //const string childName = "_child_";
            //var xdoc = XDocument.Parse(sampleXml);
            //var element = xdoc.XPathSelectElement("breakfast_menu/food[1]");

            //element.Descendants().Count().ShouldBe(4);
            //var returnedChild = element.AddChild(childName);
            //element.Descendants().Count().ShouldBe(5);

            //var child = xdoc.XPathSelectElement("breakfast_menu/food/" + childName);
            //child.ShouldNotBeNull();
            //child.ShouldBe(returnedChild);
        }

        [Fact]
        public void AddAttribute_CorrectInformation_CorrectResult()
        {
            //const string attributeName = "_attribute_";
            //const string attributeValue = "_value_";
            //var xdoc = XDocument.Parse(sampleXml);
            //var element = xdoc.XPathSelectElement("breakfast_menu/food[1]");

            //element.Attributes().ShouldBeEmpty();
            //var returnedElement = element.AddAttribute(attributeName, attributeValue);
            //returnedElement.ShouldBe(element);
            //element.Attributes().Count().ShouldBe(1);
            //element.Attribute(attributeName).Value.ShouldBe(attributeValue);
        }
    }
}