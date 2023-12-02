// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CDecodeParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>解码参数</summary>
  public class CDecodeParam
  {
    /// <summary>输入的图像信息</summary>
    public CImage InImage { get; set; }

    /// <summary>输出的图像信息</summary>
    public CImage OutImage { get; set; }

    /// <summary>水印信息</summary>
    public CFrameSpecInfo FrameSpecInfo { get; set; }

    /// <summary>构造函数</summary>
    public CDecodeParam()
    {
      this.InImage = new CImage();
      this.OutImage = new CImage();
      this.FrameSpecInfo = new CFrameSpecInfo();
    }
  }
}
