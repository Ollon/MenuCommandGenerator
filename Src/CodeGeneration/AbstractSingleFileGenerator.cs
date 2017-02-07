// Decompiled with JetBrains decompiler
// Type: Ollon.VisualStudio.CodeGeneration.AbstractSingleFileGenerator
// Assembly: Ollon.VisualStudio.CodeGeneration.SingleFileGenerators, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1857F8BA-7F92-4512-A90D-846BFBF6AD5E
// Assembly location: C:\Users\Administrator\Downloads\Ollon.VisualStudio.CodeGeneration.SingleFileGenerators.1.0.0-pre\lib\net462\Ollon.VisualStudio.CodeGeneration.SingleFileGenerators.dll

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
      get
      {
        return this.codeFileNameSpace;
      }
    }

    protected string InputFilePath
    {
      get
      {
        return this.codeFilePath;
      }
    }

    internal IVsGeneratorProgress CodeGeneratorProgress
    {
      get
      {
        return this.codeGeneratorProgress;
      }
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
      this.codeFilePath = wszInputFilePath;
      this.codeFileNameSpace = wszDefaultNamespace;
      this.codeGeneratorProgress = pGenerateProgress;
      byte[] bytes = Encoding.ASCII.GetBytes(this.GenerateCode(bstrInputFileContents));
      if (bytes == null)
      {
        rgbOutputFileContents = null;
        pcbOutput = 0U;
        return -2147467259;
      }
      int length = bytes.Length;
      rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(length);
      Marshal.Copy(bytes, 0, rgbOutputFileContents[0], length);
      pcbOutput = (uint) length;
      return 0;
    }

    public abstract string GenerateCode(string inputFileContents);
  }
}
