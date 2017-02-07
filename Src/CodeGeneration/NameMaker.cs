using System.Xml.Serialization;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class NameMaker
    {
        public static string MakeCommandIDName(string id)
        {
            return string.Format("{0}CommandId", CodeIdentifier.MakePascal(id));
        }

        public static string MakeExecuteCommandMethodName(string id)
        {
            return string.Format("OnExecute{0}", CodeIdentifier.MakePascal(id));
        }

        public static string MakeBeforeQueryStatusMethodName(string id)
        {
            return string.Format("OnBeforeQueryStatus{0}", CodeIdentifier.MakePascal(id));
        }
    }
}
