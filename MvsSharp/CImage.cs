// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CImage
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Runtime.InteropServices;

namespace MvsSharp
{
  /// <summary>图像类</summary>
  public class CImage : ICloneable
  {
    /// <summary>Buffer Address</summary>
    private IntPtr pBufAddr;
    /// <summary>图像数据</summary>
    private byte[] pBufData;
    /// <summary>Buffer Size(分配内存时需要用到)</summary>
    private uint nBufSize;
    /// <summary>帧长度</summary>
    private uint nFrameLen;
    /// <summary>像素格式</summary>
    private MvGvspPixelType enPixelType;
    /// <summary>图像宽</summary>
    private ushort nWidth;
    /// <summary>图像高</summary>
    private ushort nHeight;
    /// <summary>是否需要在C#中释放pBufAddr</summary>
    private bool bMustBeDisposed;
    /// <summary>是否是HB格式(用户可能需要HB解码前的buffer数据)</summary>
    private bool bHBPixelType;
    /// <summary>图像宽扩展</summary>
    private uint nExtendWidth;
    /// <summary>图像高扩展</summary>
    private uint nExtendHeight;

    /// <summary>内存拷贝</summary>
    /// <param name="dest">目标缓存</param>
    /// <param name="src">源缓存</param>
    /// <param name="count">拷贝大小</param>
    [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
    private static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

    /// <summary>获取图像缓存</summary>
    public IntPtr ImageAddr
    {
      get => this.pBufAddr;
      set => this.pBufAddr = value;
    }

    /// <summary>获取图像缓存(byte数组形式)</summary>
    public byte[] ImageData
    {
      get
      {
        if (IntPtr.Zero == this.pBufAddr)
          return (byte[]) null;
        this.pBufData = new byte[(int) this.nFrameLen];
        Marshal.Copy(this.pBufAddr, this.pBufData, 0, (int) this.nFrameLen);
        return this.pBufData;
      }
      set
      {
        this.pBufData = new byte[value.Length];
        this.pBufData = value;
      }
    }

    /// <summary>获取和设置图像大小</summary>
    public uint ImageSize
    {
      get => this.nBufSize;
      set => this.nBufSize = value;
    }

    /// <summary>图像的实际长度</summary>
    public uint FrameLen
    {
      get => this.nFrameLen;
      set => this.nFrameLen = value;
    }

    /// <summary>获取图像像素格式</summary>
    public MvGvspPixelType PixelType
    {
      get => this.enPixelType;
      set => this.enPixelType = value;
    }

    /// <summary>图像宽度</summary>
    public ushort Width
    {
      get => this.nWidth;
      set => this.nWidth = value;
    }

    /// <summary>图像高度</summary>
    public ushort Height
    {
      get => this.nHeight;
      set => this.nHeight = value;
    }

    /// <summary>图像宽度扩展</summary>
    public uint ExtendWidth
    {
      get => this.nExtendWidth;
      set => this.nExtendWidth = value;
    }

    /// <summary>图像高度扩展</summary>
    public uint ExtendHeight
    {
      get => this.nExtendHeight;
      set => this.nExtendHeight = value;
    }

    /// <summary>是否是HB格式的图像数据</summary>
    public bool IsHBPixelType => CInnerTool.IsHBPixelType(this.enPixelType);

    /// <summary>无参构造函数</summary>
    public CImage()
    {
      this.pBufAddr = IntPtr.Zero;
      this.bMustBeDisposed = false;
      this.pBufData = (byte[]) null;
      this.nBufSize = 0U;
      this.nWidth = (ushort) 0;
      this.nHeight = (ushort) 0;
      this.nFrameLen = 0U;
      this.enPixelType = MvGvspPixelType.PixelType_Gvsp_Undefined;
      this.bHBPixelType = false;
      this.nExtendWidth = 0U;
      this.nExtendHeight = 0U;
    }

    /// <summary>录像时只需要知道图像的宽高和像素格式</summary>
    /// <param name="width">图像宽</param>
    /// <param name="height">图像高</param>
    /// <param name="pixel_type">像素格式</param>
    public CImage(ushort width, ushort height, MvGvspPixelType pixel_type)
    {
      this.nWidth = width;
      this.nHeight = height;
      this.enPixelType = pixel_type;
      this.bHBPixelType = CInnerTool.IsHBPixelType(pixel_type);
      this.pBufAddr = IntPtr.Zero;
      this.bMustBeDisposed = false;
      this.pBufData = (byte[]) null;
      this.nBufSize = 0U;
      this.nFrameLen = 0U;
      this.nExtendWidth = 0U;
      this.nExtendHeight = 0U;
    }

    /// <summary>构造函数(主要用于GetImageBuffer接口)</summary>
    /// <param name="pBufAddr">图像缓存地址</param>
    /// <param name="enPixelType">图像像素格式</param>
    /// <param name="nFrameLen">图像实际长度</param>
    /// <param name="nHeight">图像高度</param>
    /// <param name="nWidth">图像宽度</param>
    /// <param name="nHeightEx">图像高度扩展</param>
    /// <param name="nWidthEx">图像宽度扩展</param>
    public CImage(
      IntPtr pBufAddr,
      MvGvspPixelType enPixelType,
      uint nFrameLen,
      ushort nHeight,
      ushort nWidth,
      uint nHeightEx,
      uint nWidthEx)
    {
      this.pBufAddr = pBufAddr;
      this.enPixelType = enPixelType;
      this.nFrameLen = nFrameLen;
      this.nHeight = nHeight;
      this.nWidth = nWidth;
      this.bHBPixelType = CInnerTool.IsHBPixelType(enPixelType);
      this.nExtendHeight = nHeightEx;
      this.nExtendWidth = nWidthEx;
    }

    /// <summary>构造函数(主要用于GetOneFrameTimeout接口)</summary>
    /// <param name="pBufData">图像缓存</param>
    /// <param name="enPixelType">图像像素格式</param>
    /// <param name="nFrameLen">图像实际长度</param>
    /// <param name="nHeight">图像高度</param>
    /// <param name="nWidth">图像宽度</param>
    /// <param name="nHeightEx">图像高度扩展</param>
    /// <param name="nWidthEx">图像宽度扩展</param>
    public CImage(
      byte[] pBufData,
      MvGvspPixelType enPixelType,
      uint nFrameLen,
      ushort nHeight,
      ushort nWidth,
      uint nHeightEx,
      uint nWidthEx)
    {
      this.pBufAddr = Marshal.UnsafeAddrOfPinnedArrayElement((Array) pBufData, 0);
      this.enPixelType = enPixelType;
      this.nFrameLen = nFrameLen;
      this.nHeight = nHeight;
      this.nWidth = nWidth;
      this.bHBPixelType = CInnerTool.IsHBPixelType(enPixelType);
      this.nExtendHeight = nHeightEx;
      this.nExtendWidth = nWidthEx;
    }

    /// <summary>构造函数</summary>
    /// <param name="pcOldImage"></param>
    public CImage(CImage pcOldImage)
    {
      this.nBufSize = pcOldImage.nBufSize;
      this.nWidth = pcOldImage.nWidth;
      this.nHeight = pcOldImage.nHeight;
      this.nFrameLen = pcOldImage.nFrameLen;
      this.enPixelType = pcOldImage.enPixelType;
      this.pBufAddr = Marshal.AllocHGlobal((int) this.nFrameLen);
      CImage.CopyMemory(this.pBufAddr, pcOldImage.pBufAddr, pcOldImage.nFrameLen);
      this.pBufData = (byte[]) null;
      this.bMustBeDisposed = true;
      this.bHBPixelType = CInnerTool.IsHBPixelType(pcOldImage.enPixelType);
      this.nExtendHeight = pcOldImage.nExtendHeight;
      this.nExtendWidth = pcOldImage.nExtendWidth;
    }

    /// <summary>析构函数</summary>
    ~CImage()
    {
      if (!(IntPtr.Zero != this.pBufAddr) || !this.bMustBeDisposed)
        return;
      Marshal.FreeHGlobal(this.pBufAddr);
      this.pBufAddr = IntPtr.Zero;
    }

    /// <summary>CImage的拷贝函数</summary>
    /// <returns>返回拷贝后的CImage</returns>
    public object Clone() => (object) new CImage(this);

    /// <summary>Allocate unmanaged memory.</summary>
    /// <param name="nPreBufSize">Memory Size</param>
    /// <returns></returns>
    public int AllocateUnmanagedMemory(uint nPreBufSize)
    {
      if (IntPtr.Zero == this.pBufAddr || nPreBufSize > this.nBufSize)
      {
        if (IntPtr.Zero != this.pBufAddr)
        {
          Marshal.FreeHGlobal(this.pBufAddr);
          this.pBufAddr = IntPtr.Zero;
        }
        this.pBufAddr = Marshal.AllocHGlobal((int) nPreBufSize);
        if (this.pBufAddr == IntPtr.Zero)
          return -2147483642;
        this.nBufSize = nPreBufSize;
        this.bMustBeDisposed = true;
      }
      return 0;
    }

    /// <summary>更新图像信息(SaveImageEx、SavePointCloudData接口使用)</summary>
    /// <param name="pBufAddr"></param>
    /// <param name="nFrameLen"></param>
    public void UpdateImageInfo(IntPtr pBufAddr, uint nFrameLen)
    {
      this.pBufAddr = pBufAddr;
      this.nFrameLen = nFrameLen;
    }

    /// <summary>更新图像信息</summary>
    /// <param name="pBufAddr">图像缓存地址</param>
    /// <param name="nFrameLen">图像实际长度</param>
    /// <param name="nHeight">图像高度</param>
    /// <param name="nWidth">图像宽度</param>
    /// <param name="enPixelType">像素格式</param>
    /// <param name="nHeightEx">图像高度扩展</param>
    /// <param name="nWidthEx">图像宽度扩展</param>
    public void UpdateImageInfo(
      IntPtr pBufAddr,
      uint nFrameLen,
      ushort nHeight,
      ushort nWidth,
      MvGvspPixelType enPixelType,
      uint nHeightEx,
      uint nWidthEx)
    {
      this.pBufAddr = pBufAddr;
      this.nFrameLen = nFrameLen;
      this.nHeight = nHeight;
      this.nWidth = nWidth;
      this.enPixelType = enPixelType;
      this.nExtendHeight = nHeightEx;
      this.nExtendWidth = nWidthEx;
    }
  }
}
