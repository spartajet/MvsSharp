// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CReconstructImageParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>图像重组参数信息</summary>
  public class CReconstructImageParam
  {
    /// <summary>原始输入图像</summary>
    public CImage InImage { get; set; }

    /// <summary>曝光个数(1-8]</summary>
    public uint ExposureNum { get; set; }

    /// <summary>图像重构方式</summary>
    public MV_IMAGE_RECONSTRUCTION_METHOD ReconstructMethod { get; set; }

    /// <summary>输出的图像列表</summary>
    public CImage[] OutImages { get; set; }

    /// <summary>构造函数</summary>
    public CReconstructImageParam()
    {
      this.InImage = new CImage();
      this.OutImages = new CImage[8];
    }
  }
}
