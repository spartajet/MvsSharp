// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CRecordParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>录像参数</summary>
  public class CRecordParam
  {
    /// <summary>图像宽信息</summary>
    public uint Width { get; set; }

    /// <summary>图像高信息</summary>
    public uint Height { get; set; }

    /// <summary>图像像素信息</summary>
    public MvGvspPixelType enPixelType { get; set; }

    /// <summary>帧率fps(大于1/16)</summary>
    public float FrameRate { get; set; }

    /// <summary>码率kbps(128kbps-16Mbps)</summary>
    public uint BitRate { get; set; }

    /// <summary>录像格式</summary>
    public MV_RECORD_FORMAT_TYPE RecordFmtType { get; set; }

    /// <summary>录像文件存放路径</summary>
    public string FilePath { get; set; }
  }
}
