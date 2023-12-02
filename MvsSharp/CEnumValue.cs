// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CEnumValue
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>枚举型参数信息</summary>
  public class CEnumValue
  {
    /// <summary>当前值</summary>
    public uint CurValue { get; set; }

    /// <summary>所支持的元素数量</summary>
    /// // 当前值
    public uint SupportedNum { get; set; }

    /// <summary>所支持的元素</summary>
    public uint[] SupportValue { get; set; }

    /// <summary>构造函数</summary>
    public CEnumValue() => this.SupportValue = new uint[64];
  }
}
