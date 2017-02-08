﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.VisualStudio.LanguageServices;
using System.Threading;
using System.Xml.Linq;

namespace Ollon.VisualStudio.CodeGeneration
{
    public static class MenuCommandCodeGenerator
    {
        public static CompilationUnitSyntax Generate(XDocument vsctDocument, string desiredNamespaceName)
        {
            VisualStudioWorkspace componentModelService = Services.GetComponentModelService<VisualStudioWorkspace>();
            return (CompilationUnitSyntax)Formatter.Format(SyntaxFactory.CompilationUnit().WithUsings(SyntaxFactory.List<UsingDirectiveSyntax>(new UsingDirectiveSyntax[3]
            {
         SyntaxNodeExtensions.WithLeadingTrivia( Usings.System, GenerateAutoGeneratedHeader()),
        Usings.SystemComponentModelDesign,
        Usings.MicrosoftVisualStudioShell
            })).AddMembers(new MemberDeclarationSyntax[1]
            {
         SyntaxFactory.NamespaceDeclaration( SyntaxFactory.IdentifierName(desiredNamespaceName)).AddMembers(new MemberDeclarationSyntax[1]
        {
           ClassGenerator.GeneratePackageGuidsClass(vsctDocument)
        }).AddMembers(new MemberDeclarationSyntax[1]
        {
           ClassGenerator.GeneratePackageIdsClass(vsctDocument)
        }).AddMembers(new MemberDeclarationSyntax[1]
        {
           ClassGenerator.GenerateCommandIdsClass(vsctDocument)
        }).AddMembers(new MemberDeclarationSyntax[1]
        {
           ClassGenerator.GenerateAbstractCommandFacadeClass(vsctDocument)
        }).AddMembers(new MemberDeclarationSyntax[1]
        {
           ClassGenerator.GenerateCommandFacadeClass()
        }).AddMembers(new MemberDeclarationSyntax[1]
        {
           ClassGenerator.GenerateCommandRegistrarClass(vsctDocument)
        })
            }), componentModelService, null, new CancellationToken());
        }

        private static DocumentationCommentTriviaSyntax GenerateSummaryDocumentationComment(string summary)
        {
            return SyntaxFactory.DocumentationCommentTrivia((SyntaxKind)8544, SyntaxFactory.List(new XmlNodeSyntax[]
            {
         SyntaxFactory.XmlText().WithTextTokens(SyntaxFactory.TokenList(SyntaxFactory.XmlTextLiteral(SyntaxFactory.TriviaList(SyntaxFactory.DocumentationCommentExterior("///")), " ", " ", SyntaxFactory.TriviaList()))),
         SyntaxFactory.XmlElement(SyntaxFactory.XmlElementStartTag(SyntaxFactory.XmlName(SyntaxFactory.Identifier("summary"))), SyntaxFactory.XmlElementEndTag(SyntaxFactory.XmlName(SyntaxFactory.Identifier("summary")))).WithContent( SyntaxFactory.SingletonList<XmlNodeSyntax>( SyntaxFactory.XmlText().WithTextTokens(SyntaxFactory.TokenList(new SyntaxToken[4]
        {
          SyntaxFactory.XmlTextNewLine(
              SyntaxFactory.TriviaList(), "\n", "\n", SyntaxFactory.TriviaList()),
          SyntaxFactory.XmlTextLiteral(SyntaxFactory.TriviaList(SyntaxFactory.DocumentationCommentExterior("    ///")), " " + summary, " " + summary, SyntaxFactory.TriviaList()),
          SyntaxFactory.XmlTextNewLine(SyntaxFactory.TriviaList(), "\n", "\n", SyntaxFactory.TriviaList()),
          SyntaxFactory.XmlTextLiteral(SyntaxFactory.TriviaList(SyntaxFactory.DocumentationCommentExterior("    ///")), " ", " ", SyntaxFactory.TriviaList())
        })))),
         SyntaxFactory.XmlText().WithTextTokens(SyntaxFactory.TokenList(SyntaxFactory.XmlTextNewLine(SyntaxFactory.TriviaList(), "\n", "\n", SyntaxFactory.TriviaList())))
            }));
        }

        private static SyntaxTriviaList GenerateAutoGeneratedHeader()
        {
            return SyntaxFactory.TriviaList(new SyntaxTrivia[11]
            {
        SyntaxFactory.Comment("// ------------------------------------------------------------------------------"),
        SyntaxFactory.CarriageReturnLineFeed,
        SyntaxFactory.Comment("// <auto-generated>"),
        SyntaxFactory.CarriageReturnLineFeed,
        SyntaxFactory.Comment("//     This file was auto generated by MenuCommandGenerator."),
        SyntaxFactory.CarriageReturnLineFeed,
        SyntaxFactory.Comment("// </auto-generated>"),
        SyntaxFactory.CarriageReturnLineFeed,
        SyntaxFactory.Comment("// ------------------------------------------------------------------------------"),
        SyntaxFactory.CarriageReturnLineFeed,
        SyntaxFactory.CarriageReturnLineFeed
            });
        }
    }
}