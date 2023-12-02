// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CPixelConvertParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>像素转换信息</summary>
  public class CPixelConvertParam
  {
    /// <summary>输入的图像信息</summary>
    public CImage InImage { get; set; }

    /// <summary>输出的图像信息</summary>
    public CImage OutImage { get; set; }

    /// <summary>构造函数</summary>
    public CPixelConvertParam()
    {
      this.InImage = new CImage();
      this.OutImage = new CImage();
    }
  }
}
