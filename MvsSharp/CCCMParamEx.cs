// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CCCMParamEx
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>CCM参数Ex</summary>
  public class CCCMParamEx
  {
    /// <summary>是否启用CCM</summary>
    public bool CCMEnable { get; set; }

    /// <summary>量化3x3矩阵</summary>
    public int[] CCMat { get; set; }

    /// <summary>量化系数（2的整数幂）</summary>
    public uint CCMScale { get; set; }

    /// <summary>构造函数</summary>
    public CCCMParamEx() => this.CCMat = new int[9];
  }
}
