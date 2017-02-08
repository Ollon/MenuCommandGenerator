using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ollon.VisualStudio.CodeGeneration
{
    public abstract class AbstractSingleFileGenerator : IVsSingleFileGenerator
    {
        private string codeFileNameSpace = string.Empty;
        private string codeFilePath = string.Empty;
        private IVsGeneratorProgress codeGeneratorProgress;

        protected string FileNameSpace
        {
            get { return codeFileNameSpace; }
        }

        protected string InputFilePath
        {
            get { return codeFilePath; }
        }

        internal IVsGeneratorProgress CodeGeneratorProgress
        {
            get { return codeGeneratorProgress; }
        }

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".cs";
            return 0;
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            if (bstrInputFileContents == null)
                throw new ArgumentNullException(bstrInputFileContents);
            codeFilePath = wszInputFilePath;
            codeFileNameSpace = wszDefaultNamespace;
            codeGeneratorProgress = pGenerateProgress;
            byte[] bytes = Encoding.ASCII.GetBytes(GenerateCode(bstrInputFileContents));
            if (bytes == null)
            {
                rgbOutputFileContents = null;
                pcbOutput = 0U;
                return -2147467259;
            }
            int length = bytes.Length;
            rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(length);
            Marshal.Copy(bytes, 0, rgbOutputFileContents[0], length);
            pcbOutput = (uint)length;
            return 0;
        }

        public abstract string GenerateCode(string inputFileContents);
    }
}
