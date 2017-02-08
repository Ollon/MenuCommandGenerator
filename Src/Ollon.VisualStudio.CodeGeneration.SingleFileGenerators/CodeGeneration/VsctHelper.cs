using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Xml.Linq;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class VsctHelper
    {
        public static string GetGuidSymbolNameForButtonName(XDocument vsctDocument, string buttonName)
        {
            string str = string.Empty;
            foreach (XElement element1 in vsctDocument.Root.Element(XNames.Symbols).Elements(XNames.GuidSymbol))
            {
                foreach (XElement element2 in element1.Elements(XNames.IDSymbol))
                {
                    if (element2.AttributeValueNull("name") == buttonName)
                        str = element1.AttributeValueNull("name");
                }
            }
            return str;
        }

        public static BlockSyntax GenerateRegisterCommandStatementsBlock(XDocument vsctDocument)
        {
            BlockSyntax blockSyntax = SyntaxFactory.Block();
            XElement xelement = vsctDocument.Root.Element(XNames.Commands).Element(XNames.Buttons);
            if (xelement != null && xelement.HasElements)
            {
                foreach (XElement element in xelement.Elements(XNames.Button))
                {
                    string id = element.AttributeValueNull("id");
                    blockSyntax = blockSyntax.AddStatements(new StatementSyntax[1]
                    {
            VsctHelper.GenerateRegisterCommandStatement(id)
                    });
                }
            }
            return blockSyntax;
        }

        private static StatementSyntax GenerateRegisterCommandStatement(string id)
        {
            string str1 = NameMaker.MakeExecuteCommandMethodName(id);
            string str2 = NameMaker.MakeBeforeQueryStatusMethodName(id);
            return SyntaxFactory.ExpressionStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("RegisterCommand")).WithArgumentList(SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>(new SyntaxNodeOrToken[]
            {
       SyntaxFactory.Argument( SyntaxFactory.IdentifierName("service")),
        SyntaxFactory.Token((SyntaxKind) 8216),
       SyntaxFactory.Argument( SyntaxFactory.MemberAccessExpression((SyntaxKind) 8689,  SyntaxFactory.IdentifierName("CommandIds"),  SyntaxFactory.IdentifierName(NameMaker.MakeCommandIDName(id)))),
        SyntaxFactory.Token((SyntaxKind) 8216),
       SyntaxFactory.Argument( SyntaxFactory.MemberAccessExpression((SyntaxKind) 8689,  SyntaxFactory.IdentifierName("facade"),  SyntaxFactory.IdentifierName(str1))),
        SyntaxFactory.Token((SyntaxKind) 8216),
       SyntaxFactory.Argument( SyntaxFactory.MemberAccessExpression((SyntaxKind) 8689,  SyntaxFactory.IdentifierName("facade"),  SyntaxFactory.IdentifierName(str2)))
            }))));
        }
    }
}
