// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CDisplayFrameInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>显示帧信息</summary>
  public class CDisplayFrameInfo
  {
    /// <summary>显示窗口句柄</summary>
    private IntPtr hWnd;
    /// <summary>输入的图像数据</summary>
    private CImage pcInImage;

    /// <summary>窗口句柄</summary>
    public IntPtr WindowHandle
    {
      get => this.hWnd;
      set => this.hWnd = value;
    }

    /// <summary>要显示的图像信息</summary>
    public CImage Image
    {
      get => this.pcInImage;
      set => this.pcInImage = value;
    }

    /// <summary>构造函数</summary>
    public CDisplayFrameInfo() => this.pcInImage = new CImage();
  }
}
