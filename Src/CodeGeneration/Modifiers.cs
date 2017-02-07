using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Ollon.VisualStudio.CodeGeneration
{
  internal static class Modifiers
  {
    public static readonly SyntaxToken Static = SyntaxFactory.Token((SyntaxKind) 8347);
    public static readonly SyntaxToken Abstract = SyntaxFactory.Token((SyntaxKind) 8356);
    public static readonly SyntaxToken New = SyntaxFactory.Token((SyntaxKind) 8354);
    public static readonly SyntaxToken Unsafe = SyntaxFactory.Token((SyntaxKind) 8381);
    public static readonly SyntaxToken ReadOnly = SyntaxFactory.Token((SyntaxKind) 8348);
    public static readonly SyntaxToken Virtual = SyntaxFactory.Token((SyntaxKind) 8357);
    public static readonly SyntaxToken Override = SyntaxFactory.Token((SyntaxKind) 8355);
    public static readonly SyntaxToken Sealed = SyntaxFactory.Token((SyntaxKind) 8349);
    public static readonly SyntaxToken Const = SyntaxFactory.Token((SyntaxKind) 8350);
    public static readonly SyntaxToken Event = SyntaxFactory.Token((SyntaxKind) 8358);
    public static readonly SyntaxToken Partial = SyntaxFactory.Token((SyntaxKind) 8406);
    public static readonly SyntaxToken Async = SyntaxFactory.Token((SyntaxKind) 8435);
    public static readonly SyntaxTokenList InternalStaticPartial = SyntaxFactory.TokenList(new SyntaxToken[3]
    {
      Accessibility.Internal,
      Static,
      Partial
    });
    public static readonly SyntaxTokenList InternalAbstractPartial = SyntaxFactory.TokenList(new SyntaxToken[3]
    {
      Accessibility.Internal,
      Abstract,
      Partial
    });
    public static readonly SyntaxTokenList InternalPartial = SyntaxFactory.TokenList(new SyntaxToken[2]
    {
      Accessibility.Internal,
      Partial
    });
    public static readonly SyntaxTokenList PublicStatic = SyntaxFactory.TokenList(new SyntaxToken[2]
    {
      Accessibility.Public,
      Static
    });
    public static readonly SyntaxTokenList PublicVirtual = SyntaxFactory.TokenList(new SyntaxToken[2]
    {
      Accessibility.Public,
      Virtual
    });
    public static readonly SyntaxTokenList PublicConst = SyntaxFactory.TokenList(new SyntaxToken[2]
    {
      Accessibility.Public,
      Const
    });
  }
}
