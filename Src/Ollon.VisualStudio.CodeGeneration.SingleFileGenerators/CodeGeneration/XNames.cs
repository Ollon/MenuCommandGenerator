using System.Xml.Linq;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class XNames
    {
        private static XNamespace ns = XNamespace.Get("http://schemas.microsoft.com/VisualStudio/2005-10-18/CommandTable");
        public static XName Commands = ns + "Commands";
        public static XName Buttons = ns + "Buttons";
        public static XName Button = ns + "Button";
        public static XName Symbols = ns + "Symbols";
        public static XName GuidSymbol = ns + "GuidSymbol";
        public static XName IDSymbol = ns + "IDSymbol";
    }
}
