using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class FieldGenerator
  {
    public static FieldDeclarationSyntax GenerateCommandIDField(string commandName, string commandSetName)
    {
      return SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName("CommandID")).WithVariables(SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(string.Format("{0}CommandId", commandName))).WithInitializer(SyntaxFactory.EqualsValueClause(SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName("CommandID")).WithArgumentList(SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>(new SyntaxNodeOrToken[3]
      {
        SyntaxFactory.Argument( SyntaxFactory.MemberAccessExpression((SyntaxKind) 8689,  SyntaxFactory.IdentifierName("GuidSymbols"), (SimpleNameSyntax) SyntaxFactory.IdentifierName(commandSetName))),
        SyntaxFactory.Token((SyntaxKind) 8216),
        SyntaxFactory.Argument( SyntaxFactory.MemberAccessExpression((SyntaxKind) 8689,  SyntaxFactory.IdentifierName("IDSymbols"), (SimpleNameSyntax) SyntaxFactory.IdentifierName(commandName)))
      })))))))).WithModifiers(Modifiers.PublicStatic);
    }

    public static FieldDeclarationSyntax GenerateConstantIntField(string name, int value)
    {
      return SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token((SyntaxKind)8309))).WithVariables(SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(name)).WithInitializer(SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression((SyntaxKind)8749, SyntaxFactory.Literal(value))))))).WithModifiers(Modifiers.PublicConst);
    }

    public static FieldDeclarationSyntax GenerateStaticGuidField(string guidFieldName)
    {
      return SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName("Guid")).WithVariables(SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(guidFieldName)).WithInitializer(SyntaxFactory.EqualsValueClause(SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName("Guid")).WithArgumentList(SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(SyntaxFactory.Argument((ExpressionSyntax)SyntaxFactory.IdentifierName(string.Format("{0}String", (object)guidFieldName))))))))))).WithModifiers(Modifiers.PublicStatic);
    }

    public static FieldDeclarationSyntax GenerateConstantGuidStringField(string name, string guid)
    {
      name += "String";
      return SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token((SyntaxKind)8316))).WithVariables(SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(name)).WithInitializer(SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression((SyntaxKind)8750, SyntaxFactory.Literal(guid))))))).WithModifiers(Modifiers.PublicConst);
    }
  }
}
