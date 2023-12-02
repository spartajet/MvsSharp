// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CFrameout
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>帧信息</summary>
  public class CFrameout
  {
    /// <summary>图像</summary>
    private CImage pcImage;
    /// <summary>Chunk</summary>
    private CChunk pcChunk;
    /// <summary>水印</summary>
    private CFrameSpecInfo pcFrameSpec;

    /// <summary>图像信息</summary>
    public CImage Image
    {
      get => this.pcImage;
      set => this.pcImage = value;
    }

    /// <summary>Chunk信息</summary>
    public CChunk Chunk
    {
      get => this.pcChunk;
      set => this.pcChunk = value;
    }

    /// <summary>水印信息</summary>
    public CFrameSpecInfo FrameSpec
    {
      get => this.pcFrameSpec;
      set => this.pcFrameSpec = value;
    }

    /// <summary>构造函数</summary>
    public CFrameout()
    {
      this.pcImage = (CImage) null;
      this.pcChunk = new CChunk();
      this.pcFrameSpec = new CFrameSpecInfo();
    }
  }
}
