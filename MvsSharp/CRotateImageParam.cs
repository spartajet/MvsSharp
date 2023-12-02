// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CRotateImageParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>旋转图像参数</summary>
  public class CRotateImageParam
  {
    /// <summary>输入的图像数据</summary>
    public CImage InImage { get; set; }

    /// <summary>输出的图像数据</summary>
    public CImage OutImage { get; set; }

    /// <summary>旋转角度</summary>
    public MV_IMG_ROTATION_ANGLE RotationAngle { get; set; }

    /// <summary>构造函数</summary>
    public CRotateImageParam()
    {
      this.InImage = new CImage();
      this.OutImage = new CImage();
    }
  }
}
