// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CAllMatchInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>各种类型的信息</summary>
  public class CAllMatchInfo
  {
    /// <summary>需要输出的信息类型，如MV_MATCH_TYPE_NET_DETECT</summary>
    public MV_MATCH_TYPE Type { get; set; }

    /// <summary>输出的信息缓存，由调用者分配</summary>
    public IntPtr Info { get; set; }

    /// <summary>信息缓存的大小</summary>
    public uint InfoSize { get; set; }
  }
}
