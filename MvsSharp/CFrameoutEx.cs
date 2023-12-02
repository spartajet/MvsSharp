// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CFrameoutEx
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>帧信息(不含图像缓存)</summary>
  public class CFrameoutEx
  {
    /// <summary>图像信息(仅包含图像基本信息，不含图像缓存)</summary>
    public CImageEx pcImageInfoEx { get; set; }

    /// <summary>Chunk信息</summary>
    public CChunk Chunk { get; set; }

    /// <summary>水印信息</summary>
    public CFrameSpecInfo FrameSpec { get; set; }

    /// <summary>构造函数</summary>
    public CFrameoutEx()
    {
      this.pcImageInfoEx = new CImageEx();
      this.Chunk = new CChunk();
      this.FrameSpec = new CFrameSpecInfo();
    }
  }
}
