// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CRectArea
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>矩形框区域信息</summary>
  public class CRectArea
  {
    /// <summary>矩形上边缘距离图像上边缘的距离，根据图像的相对位置，范围为[0.0 , 1.0]</summary>
    public float Top { get; set; }

    /// <summary>矩形下边缘距离图像下边缘的距离，根据图像的相对位置，范围为[0.0 , 1.0]</summary>
    public float Bottom { get; set; }

    /// <summary>矩形左边缘距离图像左边缘的距离，根据图像的相对位置，范围为[0.0 , 1.0]</summary>
    public float Left { get; set; }

    /// <summary>矩形右边缘距离图像右边缘的距离，根据图像的相对位置，范围为[0.0 , 1.0]</summary>
    public float Right { get; set; }

    /// <summary>辅助线宽度</summary>
    public uint LineWidth { get; set; }

    /// <summary>辅助线颜色</summary>
    public CColor Color { get; set; }

    /// <summary>构造函数</summary>
    public CRectArea() => this.Color = new CColor();
  }
}
