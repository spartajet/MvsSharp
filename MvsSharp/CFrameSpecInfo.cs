// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CFrameSpecInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>水印信息</summary>
  public class CFrameSpecInfo
  {
    /// <summary>[OUT]     秒数</summary>
    public uint SecondCount { get; set; }

    /// <summary>[OUT]     周期数</summary>
    public uint CycleCount { get; set; }

    /// <summary>[OUT]     周期偏移量</summary>
    public uint CycleOffset { get; set; }

    /// <summary>[OUT]     增益</summary>
    public float Gain { get; set; }

    /// <summary>[OUT]     曝光时间</summary>
    public float ExposureTime { get; set; }

    /// <summary>[OUT]     平均亮度</summary>
    public uint AverageBrightness { get; set; }

    /// <summary>[OUT]     红色</summary>
    public uint Red { get; set; }

    /// <summary>[OUT]     绿色</summary>
    public uint Green { get; set; }

    /// <summary>[OUT]     蓝色</summary>
    public uint Blue { get; set; }

    /// <summary>[OUT]     总帧数</summary>
    public uint FrameCounter { get; set; }

    /// <summary>[OUT]     触发计数</summary>
    public uint TriggerIndex { get; set; }

    /// <summary>[OUT]     输入</summary>
    public uint Input { get; set; }

    /// <summary>[OUT]     输出</summary>
    public uint Output { get; set; }

    /// <summary>[OUT]     水平偏移量</summary>
    public ushort OffsetX { get; set; }

    /// <summary>[OUT]     垂直偏移量</summary>
    public ushort OffsetY { get; set; }

    /// <summary>[OUT]     水印宽</summary>
    public ushort FrameWidth { get; set; }

    /// <summary>[OUT]     水印高</summary>
    public ushort FrameHeight { get; set; }

    /// <summary>帧号</summary>
    public uint FrameNum { get; set; }

    /// <summary>时间戳高32位</summary>
    public uint DevTimeStampHigh { get; set; }

    /// <summary>时间戳低32位</summary>
    public uint DevTimeStampLow { get; set; }

    /// <summary>主机生成的时间戳</summary>
    public long HostTimeStamp { get; set; }

    /// <summary>丢包数</summary>
    public uint LostPacket { get; set; }
  }
}
