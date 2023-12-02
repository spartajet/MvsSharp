// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CLinesArea
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>线条辅助线信息</summary>
  public class CLinesArea
  {
    /// <summary>辅助线宽度</summary>
    public uint LineWidth { get; set; }

    /// <summary>辅助线颜色信息</summary>
    public CColor Color { get; set; }

    /// <summary>线条辅助线的起始点坐标</summary>
    public CPoint StartPoint { get; set; }

    /// <summary>线条辅助线的终点坐标</summary>
    public CPoint EndPoint { get; set; }

    /// <summary>构造函数</summary>
    public CLinesArea()
    {
      this.Color = new CColor();
      this.StartPoint = new CPoint();
      this.EndPoint = new CPoint();
    }
  }
}
