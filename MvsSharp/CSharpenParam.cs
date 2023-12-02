// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CSharpenParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>锐化参数</summary>
  public class CSharpenParam
  {
    /// <summary>输入的图像数据</summary>
    public CImage InImage { get; set; }

    /// <summary>输出的图像数据</summary>
    public CImage OutImage { get; set; }

    /// <summary>锐度调节强度，范围:[0, 500]</summary>
    public uint SharpenAmount { get; set; }

    /// <summary>锐度调节半径（半径越大，耗时越长），范围:[1, 21]</summary>
    public uint SharpenRadius { get; set; }

    /// <summary>锐度调节阈值，范围:[0, 255]</summary>
    public uint SharpenThreshold { get; set; }

    /// <summary>构造函数</summary>
    public CSharpenParam()
    {
      this.InImage = new CImage();
      this.OutImage = new CImage();
    }
  }
}
