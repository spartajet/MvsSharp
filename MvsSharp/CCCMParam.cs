// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CCCMParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>CCM参数</summary>
  public class CCCMParam
  {
    /// <summary>[IN]     是否启用CCM</summary>
    public bool CCMEnable { get; set; }

    /// <summary>[IN]     CCM矩阵(-8192~8192)</summary>
    public int[] CCMat { get; set; }

    /// <summary>构造函数</summary>
    public CCCMParam() => this.CCMat = new int[9];
  }
}
