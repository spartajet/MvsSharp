// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CSaveImgToFileParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>保存图像到文件参数信息</summary>
  public class CSaveImgToFileParam
  {
    /// <summary>输入的图像信息</summary>
    public CImage Image { get; set; }

    /// <summary>[IN]     输入图片格式</summary>
    public MV_SAVE_IAMGE_TYPE ImageType { get; set; }

    /// <summary>[IN]     编码质量, (0-100]</summary>
    public uint Quality { get; set; }

    /// <summary>[IN]     输入文件路径</summary>
    public string ImagePath { get; set; }

    /// <summary>[IN]     Bayer的插值方法 0-快速 1-均衡 2-最优（如果传入其它值则默认为最优）</summary>
    public uint MethodValue { get; set; }

    /// <summary>构造函数</summary>
    public CSaveImgToFileParam() => this.Image = new CImage();
  }
}
