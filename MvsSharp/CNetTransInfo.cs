// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CNetTransInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>网络传输信息</summary>
  public class CNetTransInfo
  {
    /// <summary>已接收数据大小  [统计StartGrabbing和StopGrabbing之间的数据量]</summary>
    public long ReviceDataSize { get; set; }

    /// <summary>丢帧数量</summary>
    public int ThrowFrameCount { get; set; }

    /// <summary>接收的帧数</summary>
    public uint NetRecvFrameCount { get; set; }

    /// <summary>请求重发包数</summary>
    public long RequestResendPacketCount { get; set; }

    /// <summary>重发包数</summary>
    public long ResendPacketCount { get; set; }
  }
}
