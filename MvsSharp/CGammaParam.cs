// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CGammaParam
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>Gamma参数信息</summary>
  public class CGammaParam
  {
    /// <summary>Gamma类型</summary>
    public MV_CC_GAMMA_TYPE GammaType { get; set; }

    /// <summary>Gamma值</summary>
    public float GammaValue { get; set; }

    /// <summary>Gamma曲线缓存</summary>
    public IntPtr GammaCurveBuf { get; set; }

    /// <summary>Gamma曲线长度</summary>
    public uint GammaCurveBufLen { get; set; }
  }
}
