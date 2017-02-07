using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class MethodGenerator
    {
        public static MethodDeclarationSyntax GenerateRegisterCommandsMethod(XDocument vsctDocument)
        {
            return SyntaxFactory.MethodDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token((SyntaxKind)8318)), SyntaxFactory.Identifier("RegisterCommands")).WithModifiers(SyntaxFactory.TokenList(new SyntaxToken[2]
            {
        SyntaxFactory.Token((SyntaxKind) 8343),
        SyntaxFactory.Token((SyntaxKind) 8347)
            })).WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(new SyntaxNodeOrToken[3]
            {
        SyntaxFactory.Parameter(SyntaxFactory.Identifier("service")).WithType( SyntaxFactory.IdentifierName("OleMenuCommandService")),
        SyntaxFactory.Token((SyntaxKind) 8216),
        SyntaxFactory.Parameter(SyntaxFactory.Identifier("facade")).WithType( SyntaxFactory.IdentifierName("CommandFacade"))
            }))).WithBody(VsctHelper.GenerateRegisterCommandStatementsBlock(vsctDocument));
        }

        public static MethodDeclarationSyntax GenerateRegisterCommandMethod()
        {
            return SyntaxFactory.MethodDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token((SyntaxKind)8318)), SyntaxFactory.Identifier("RegisterCommand")).WithModifiers(SyntaxFactory.TokenList(new SyntaxToken[2]
            {
        SyntaxFactory.Token((SyntaxKind) 8343),
        SyntaxFactory.Token((SyntaxKind) 8347)
            })).WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(new SyntaxNodeOrToken[]
            {
        SyntaxFactory.Parameter(SyntaxFactory.Identifier("service")).WithType( SyntaxFactory.IdentifierName("OleMenuCommandService")),
        SyntaxFactory.Token((SyntaxKind) 8216),
        SyntaxFactory.Parameter(SyntaxFactory.Identifier("cmdId")).WithType( SyntaxFactory.IdentifierName("CommandID")),
              SyntaxFactory.Token((SyntaxKind)8216),
              SyntaxFactory.Parameter(SyntaxFactory.Identifier("commandHandler")).WithType(SyntaxFactory.IdentifierName("EventHandler")),
              SyntaxFactory.Token((SyntaxKind)8216),
        SyntaxFactory.Parameter(SyntaxFactory.Identifier("queryHandler")).WithType(SyntaxFactory.IdentifierName("EventHandler"))
          }))).WithBody(SyntaxFactory.Block(new StatementSyntax[]
      {
         SyntaxFactory.LocalDeclarationStatement(SyntaxFactory.VariableDeclaration( SyntaxFactory.IdentifierName("OleMenuCommand")).WithVariables( SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>( SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier("command")).WithInitializer(SyntaxFactory.EqualsValueClause( SyntaxFactory.ObjectCreationExpression( SyntaxFactory.IdentifierName("OleMenuCommand")).WithArgumentList(SyntaxFactory.ArgumentList( SyntaxFactory.SeparatedList<ArgumentSyntax>( new SyntaxNodeOrToken[3]
        {
          SyntaxFactory.Argument( SyntaxFactory.IdentifierName("commandHandler")),
          SyntaxFactory.Token((SyntaxKind) 8216),
          SyntaxFactory.Argument( SyntaxFactory.IdentifierName("cmdId"))
        })))))))),
         SyntaxFactory.ExpressionStatement( SyntaxFactory.AssignmentExpression((SyntaxKind) 8715,  SyntaxFactory.MemberAccessExpression((SyntaxKind) 8689,  SyntaxFactory.IdentifierName("command"),  SyntaxFactory.IdentifierName("BeforeQueryStatus")),  SyntaxFactory.IdentifierName("queryHandler"))),
         SyntaxFactory.ExpressionStatement( SyntaxFactory.InvocationExpression( SyntaxFactory.MemberAccessExpression((SyntaxKind) 8689,  SyntaxFactory.IdentifierName("service"),  SyntaxFactory.IdentifierName("AddCommand"))).WithArgumentList(SyntaxFactory.ArgumentList( SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>( SyntaxFactory.Argument( SyntaxFactory.IdentifierName("command"))))))
      }));
        }

        public static MethodDeclarationSyntax GenerateFacadeCommandMethod(string commandName)
        {
            return SyntaxNodeExtensions.WithLeadingTrivia(SyntaxFactory.MethodDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token((SyntaxKind)8318)), SyntaxFactory.Identifier(commandName)).WithModifiers(Modifiers.PublicVirtual).WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(new SyntaxNodeOrToken[3]
            {
        SyntaxFactory.Parameter(SyntaxFactory.Identifier("sender")).WithType( SyntaxFactory.PredefinedType(SyntaxFactory.Token((SyntaxKind) 8319))),
        SyntaxFactory.Token((SyntaxKind) 8216),
        SyntaxFactory.Parameter(SyntaxFactory.Identifier("e")).WithType( SyntaxFactory.IdentifierName("EventArgs"))
            })))).WithBody(SyntaxFactory.Block()).WithTrailingTrivia(SyntaxFactory.TriviaList(new[]
            {
        SyntaxFactory.CarriageReturnLineFeed,
        SyntaxFactory.CarriageReturnLineFeed
            }));
        }
    }
}
