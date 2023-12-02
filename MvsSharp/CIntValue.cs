// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CIntValue
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>整型参数信息</summary>
  public class CIntValue
  {
    /// <summary>当前值</summary>
    public long CurValue { get; set; }

    /// <summary>最大值</summary>
    public long Max { get; set; }

    /// <summary>最小值</summary>
    public long Min { get; set; }

    /// <summary>步进值</summary>
    public long Inc { get; set; }
  }
}
