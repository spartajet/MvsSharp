// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CImageEx
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>图像类(仅包含图像基本信息，不含图像缓存)</summary>
  public class CImageEx
  {
    /// <summary>图像宽</summary>
    public ushort Width { get; set; }

    /// <summary>图像高</summary>
    public ushort Height { get; set; }

    /// <summary>像素格式</summary>
    public MvGvspPixelType PixelType { get; set; }

    /// <summary>帧长度</summary>
    public uint FrameLen { get; set; }

    /// <summary>图像宽扩展</summary>
    public uint nExtendWidth { get; set; }

    /// <summary>图像高扩展</summary>
    public uint nExtendHeight { get; set; }
  }
}
