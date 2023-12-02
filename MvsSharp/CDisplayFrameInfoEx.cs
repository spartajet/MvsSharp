// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CDisplayFrameInfoEx
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>显示帧信息扩展</summary>
  public class CDisplayFrameInfoEx
  {
    /// <summary>显示窗口句柄</summary>
    private IntPtr hWnd;
    /// <summary>缓存数据</summary>
    private IntPtr pBufAddr;
    /// <summary>输入的图像数据</summary>
    private CImageEx pcInImageEx;

    /// <summary>窗口句柄</summary>
    public IntPtr WindowHandle
    {
      get => this.hWnd;
      set => this.hWnd = value;
    }

    /// <summary>要显示的图像信息</summary>
    public CImageEx ImageEx
    {
      get => this.pcInImageEx;
      set => this.pcInImageEx = value;
    }

    /// <summary>获取图像缓存</summary>
    public IntPtr ImageAddr
    {
      get => this.pBufAddr;
      set => this.pBufAddr = value;
    }

    /// <summary>构造函数</summary>
    public CDisplayFrameInfoEx()
    {
      this.pcInImageEx = new CImageEx();
      this.hWnd = IntPtr.Zero;
      this.pBufAddr = IntPtr.Zero;
    }
  }
}
