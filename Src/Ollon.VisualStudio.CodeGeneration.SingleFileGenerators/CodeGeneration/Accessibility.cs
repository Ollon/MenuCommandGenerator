using Microsoft.CodeAnalysis;

namespace Ollon.VisualStudio.CodeGeneration
{
  internal static class Accessibility
  {
    public static readonly SyntaxToken Public = Keywords.Public;
    public static readonly SyntaxToken Internal = Keywords.Internal;
    public static readonly SyntaxToken Private = Keywords.Private;
    public static readonly SyntaxToken Protected = Keywords.Protected;
  }
}
