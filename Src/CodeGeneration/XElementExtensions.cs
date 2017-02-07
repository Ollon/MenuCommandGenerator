using System.Xml.Linq;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class XElementExtensions
    {
        public static string ElementValueNull(this XElement element)
        {
            return (element?.Value) ?? "";
        }

        public static string AttributeValueNull(this XElement element, string attributeName)
        {
            if (element == null)
                return "";
            XAttribute xattribute = element.Attribute(attributeName);
            return (xattribute?.Value) ?? "";
        }
    }
}
