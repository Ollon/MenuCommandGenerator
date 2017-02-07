using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;
using Microsoft.VisualStudio.LanguageServices;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class ClassGenerator
    {
        public static ClassDeclarationSyntax GeneratePackageGuidsClass(XDocument vsctDocument)
        {
            VisualStudioWorkspace componentModelService = Services.GetComponentModelService<VisualStudioWorkspace>();
            ClassDeclarationSyntax declarationSyntax = SyntaxFactory.ClassDeclaration("GuidSymbols").WithModifiers(Modifiers.InternalStaticPartial);
            XElement xelement = vsctDocument.Root.Element(XNames.Symbols);
            SyntaxList<FieldDeclarationSyntax> syntaxList = SyntaxFactory.List<FieldDeclarationSyntax>();
            foreach (XElement element in xelement.Elements(XNames.GuidSymbol))
            {
                string str = element.Attribute("name").Value;
                string guid = element.Attribute("value").Value.TrimStart('{').TrimEnd('}');
                declarationSyntax = declarationSyntax.AddMembers(new MemberDeclarationSyntax[1]
                {
           FieldGenerator.GenerateStaticGuidField(str)
                });
                syntaxList = @syntaxList.Add(FieldGenerator.GenerateConstantGuidStringField(str, guid));
            }
            SyntaxList<FieldDeclarationSyntax>.Enumerator enumerator = @syntaxList.GetEnumerator();
            while (@enumerator.MoveNext())
            {
                FieldDeclarationSyntax current = @enumerator.Current;
                declarationSyntax = declarationSyntax.AddMembers(new MemberDeclarationSyntax[1]
                {
           current
                });
            }
            return (ClassDeclarationSyntax)Formatter.Format(declarationSyntax, componentModelService, null, new CancellationToken());
        }

        public static ClassDeclarationSyntax GeneratePackageIdsClass(XDocument vsctDocument)
        {
            VisualStudioWorkspace componentModelService = Services.GetComponentModelService<VisualStudioWorkspace>();
            ClassDeclarationSyntax declarationSyntax = SyntaxFactory.ClassDeclaration("IDSymbols").WithModifiers(Modifiers.InternalStaticPartial);
            foreach (XContainer element1 in vsctDocument.Root.Element(XNames.Symbols).Elements(XNames.GuidSymbol))
            {
                foreach (XElement element2 in element1.Elements(XNames.IDSymbol))
                {
                    string name = element2.Attribute("name").Value;
                    int int32 = Convert.ToInt32(element2.Attribute("value").Value, 16);
                    declarationSyntax = declarationSyntax.AddMembers(new MemberDeclarationSyntax[1]
                    {
             FieldGenerator.GenerateConstantIntField(name, int32)
                    });
                }
            }
            return (ClassDeclarationSyntax)Formatter.Format(declarationSyntax, componentModelService, null, new CancellationToken());
        }

        public static ClassDeclarationSyntax GenerateCommandIdsClass(XDocument vsctDocument)
        {
            SyntaxList<MemberDeclarationSyntax> syntaxList = SyntaxFactory.List<MemberDeclarationSyntax>();
            XElement xelement = vsctDocument.Root.Element(XNames.Commands).Element(XNames.Buttons);
            if (xelement != null && xelement.HasElements)
            {
                foreach (XElement element in xelement.Elements(XNames.Button))
                {
                    string str = element.AttributeValueNull("id");
                    NameMaker.MakeCommandIDName(str);
                    string nameForButtonName = VsctHelper.GetGuidSymbolNameForButtonName(vsctDocument, str);
                    syntaxList = @syntaxList.Add(FieldGenerator.GenerateCommandIDField(str, nameForButtonName));
                }
            }
            return SyntaxFactory.ClassDeclaration("CommandIds")
                .WithModifiers(Modifiers.InternalStaticPartial)
                .WithMembers(syntaxList)
                .NormalizeWhitespace();
        }

        public static ClassDeclarationSyntax GenerateCommandFacadeClass()
        {
            return SyntaxFactory.ClassDeclaration("CommandFacade").WithModifiers(SyntaxFactory.TokenList(new SyntaxToken[2]
            {
        SyntaxFactory.Token((SyntaxKind) 8345),
        SyntaxFactory.Token((SyntaxKind) 8406)
            })).WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName("AbstractCommandFacade")))));
        }

        public static ClassDeclarationSyntax GenerateCommandRegistrarClass(XDocument vsctDocument)
        {
            MethodDeclarationSyntax registerCommandMethod = MethodGenerator.GenerateRegisterCommandMethod();
            MethodDeclarationSyntax registerCommandsMethod = MethodGenerator.GenerateRegisterCommandsMethod(vsctDocument);
            return SyntaxFactory.ClassDeclaration("CommandRegistrar").WithModifiers(Modifiers.InternalStaticPartial).WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(new MemberDeclarationSyntax[2]
            {
         registerCommandsMethod,
         registerCommandMethod
            }));
        }

        public static ClassDeclarationSyntax GenerateAbstractCommandFacadeClass(XDocument vsctDocument)
        {
            SyntaxList<MemberDeclarationSyntax> syntaxList = SyntaxFactory.List<MemberDeclarationSyntax>();
            syntaxList = @syntaxList.Add(ClassGenerator.GenerateProtectedConstructor("AbstractCommandFacade"));
            XElement xelement = vsctDocument.Root.Element(XNames.Commands).Element(XNames.Buttons);
            if (xelement != null && xelement.HasElements)
            {
                foreach (XElement element in xelement.Elements(XNames.Button))
                {
                    string id = element.Attribute("id").Value;
                    string commandName1 = NameMaker.MakeExecuteCommandMethodName(id);
                    string commandName2 = NameMaker.MakeBeforeQueryStatusMethodName(id);
                    syntaxList = @syntaxList.Add(MethodGenerator.GenerateFacadeCommandMethod(commandName1));
                    syntaxList = @syntaxList.Add(MethodGenerator.GenerateFacadeCommandMethod(commandName2));
                }
            }
            return SyntaxFactory.ClassDeclaration("AbstractCommandFacade")
                .WithModifiers(Modifiers.InternalAbstractPartial)
                .WithMembers(syntaxList)
                .NormalizeWhitespace();
        }

        private static ConstructorDeclarationSyntax GenerateProtectedConstructor(string className)
        {
            return SyntaxFactory.ConstructorDeclaration(
                SyntaxFactory.Identifier(className))
                .WithModifiers(SyntaxFactory.TokenList(Accessibility.Protected))
                .WithBody(SyntaxFactory.Block());
        }
    }
}
