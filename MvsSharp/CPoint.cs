// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CPoint
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>自定义点的坐标信息</summary>
  public class CPoint
  {
    /// <summary>该点距离图像左边缘距离，根据图像的相对位置，范围为[0.0 , 1.0]</summary>
    public float X { get; set; }

    /// <summary>该点距离图像上边缘距离，根据图像的相对位置，范围为[0.0 , 1.0]</summary>
    public float Y { get; set; }
  }
}
