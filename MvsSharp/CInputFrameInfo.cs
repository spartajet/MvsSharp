// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CInputFrameInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>输入帧信息</summary>
  public class CInputFrameInfo
  {
    /// <summary>输入的图像信息</summary>
    public CImage InImage { get; set; }

    /// <summary>构造函数</summary>
    public CInputFrameInfo() => this.InImage = new CImage();
  }
}
