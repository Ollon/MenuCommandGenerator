using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class Usings
    {
        public static readonly UsingDirectiveSyntax System = SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System"));
        public static readonly UsingDirectiveSyntax SystemComponentModelDesign = SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System.ComponentModel.Design"));
        public static readonly UsingDirectiveSyntax MicrosoftVisualStudioShell = SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("Microsoft.VisualStudio.Shell"));
    }
}
