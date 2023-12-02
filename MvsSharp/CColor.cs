// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CColor
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>辅助线的颜色</summary>
  public class CColor
  {
    /// <summary>红色，根据像素颜色的相对深度，范围为[0.0 , 1.0]，代表着[0, 255]的颜色深度</summary>
    public float Red { get; set; }

    /// <summary>绿色，根据像素颜色的相对深度，范围为[0.0 , 1.0]，代表着[0, 255]的颜色深度</summary>
    public float Green { get; set; }

    /// <summary>蓝色，根据像素颜色的相对深度，范围为[0.0 , 1.0]，代表着[0, 255]的颜色深度</summary>
    public float Blue { get; set; }

    /// <summary>透明度，根据像素颜色的相对透明度，范围为[0.0 , 1.0] (此参数功能暂不支持)</summary>
    public float Alpha { get; set; }
  }
}
