using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Ollon.VisualStudio.CodeGeneration;

namespace Ollon.VisualStudio.CodeGeneration
{
    [ComVisible(true)]
    [Guid("128431D8-143E-4861-83BE-58433B300763")]
    [CodeGeneratorRegistration(
          typeof(MenuCommandGenerator)
        , nameof(MenuCommandGenerator)
        , VSConstants.UICONTEXT.CSharpProject_string
        , GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(MenuCommandGenerator))]
    public class MenuCommandGenerator : AbstractSingleFileGenerator
    {
        public override string GenerateCode(string inputFileContents)
        {
            XDocument xdoc = XDocument.Parse(inputFileContents);
            CompilationUnitSyntax unit = MenuCommandCodeGenerator.Generate(xdoc, FileNameSpace);
            using (StringWriter sw = new StringWriter())
            {
                unit.WriteTo(sw);
                return sw.ToString();
            }
        }
    }
}
