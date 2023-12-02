// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CInnerTool
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MvsSharp
{
  /// <summary>内部使用的公共功能接口类</summary>
  public class CInnerTool
  {
    /// <summary>Byte array to struct</summary>
    /// <param name="bytes">Byte array</param>
    /// <param name="type">Struct type</param>
    /// <returns>Struct object</returns>
    public static object ByteToStruct(byte[] bytes, Type type)
    {
      int num1 = Marshal.SizeOf(type);
      if (num1 > bytes.Length)
        return (object) null;
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Marshal.Copy(bytes, 0, num2, num1);
      object structure = Marshal.PtrToStructure(num2, type);
      Marshal.FreeHGlobal(num2);
      return structure;
    }

    /// <summary>Struct to Byte array</summary>
    /// <param name="obj">Struct object</param>
    /// <param name="byteArr">Byte</param>
    /// <returns>Bytes </returns>
    public static void StructToBytes<T>(T obj, byte[] byteArr)
    {
      int length = Marshal.SizeOf(typeof (T));
      IntPtr num = Marshal.AllocHGlobal(length);
      Marshal.StructureToPtr((object) obj, num, false);
      byte[] numArray = new byte[length];
      Marshal.Copy(num, byteArr, 0, length);
      Marshal.FreeHGlobal(num);
    }

    /// <summary>删除byte数组缓存去尾部空白区</summary>
    /// <param name="inputStream">字符串</param>
    /// <returns></returns>
    public static byte[] BytesTrimEnd(byte[] inputStream)
    {
      List<byte> byteList = new List<byte>();
      for (int index = 0; index < inputStream.Length && inputStream[index] != (byte) 0; ++index)
        byteList.Add(inputStream[index]);
      return byteList.ToArray();
    }

    /// <summary>调试日志信息</summary>
    /// <param name="strInfo">日志信息</param>
    public static void DebugInfo(string strInfo) => Debug.WriteLine(strInfo);

    /// <summary>追踪日志信息</summary>
    /// <param name="strInfo">日志信息</param>
    public static void TraceInfo(string strInfo)
    {
    }

    /// <summary>获取从1970年1月1号到当前时间点的毫秒数【毫秒时间戳】</summary>
    /// <returns></returns>
    public static long ToUnixTime()
    {
      DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      return Convert.ToInt64((DateTime.Now.ToUniversalTime() - dateTime).TotalMilliseconds);
    }

    /// <summary>秒时间戳</summary>
    /// <returns></returns>
    public static long ToUnixSecondsTime()
    {
      DateTime now = DateTime.Now;
      DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      return Convert.ToInt64((now.ToUniversalTime() - dateTime).TotalSeconds);
    }

    /// <summary>判断像素是否为Mono格式</summary>
    /// <param name="enPixelType"></param>
    /// <returns></returns>
    public static bool IsMonoPixel(MvGvspPixelType enPixelType)
    {
      switch (enPixelType)
      {
        case MvGvspPixelType.PixelType_Gvsp_Mono1p:
        case MvGvspPixelType.PixelType_Gvsp_Mono2p:
        case MvGvspPixelType.PixelType_Gvsp_Mono4p:
        case MvGvspPixelType.PixelType_Gvsp_Mono8:
        case MvGvspPixelType.PixelType_Gvsp_Mono8_Signed:
        case MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Mono10:
        case MvGvspPixelType.PixelType_Gvsp_Mono12:
        case MvGvspPixelType.PixelType_Gvsp_Mono16:
        case MvGvspPixelType.PixelType_Gvsp_Mono14:
          return true;
        default:
          return false;
      }
    }

    /// <summary>判断图像格式是否为彩色格式</summary>
    /// <param name="enPixelType"></param>
    /// <returns></returns>
    public static bool IsColorPixel(MvGvspPixelType enPixelType)
    {
      switch (enPixelType)
      {
        case MvGvspPixelType.PixelType_Gvsp_BayerGR8:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG8:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB8:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG8:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR10:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG10:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB10:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG10:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR12:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG12:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB12:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG12:
        case MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
        case MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
        case MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
          return true;
        default:
          return false;
      }
    }

    /// <summary>判断是否是HB格式</summary>
    /// <param name="enPixelType">像素格式</param>
    /// <returns></returns>
    public static bool IsHBPixelType(MvGvspPixelType enPixelType)
    {
      switch (enPixelType)
      {
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG8:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono10:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono12:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono16:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG12:
        case MvGvspPixelType.PixelType_Gvsp_HB_YUV422_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_YUV422_YUYV_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_RGB8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BGR8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_RGBA8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BGRA8_Packed:
          return true;
        default:
          return false;
      }
    }

    /// <summary>获取图像大小</summary>
    /// <param name="enType">像素格式</param>
    /// <param name="nWidth">图像宽度</param>
    /// <param name="nHeight">图像高度</param>
    /// <returns></returns>
    public static uint GetPixelSize(MvGvspPixelType enType, uint nWidth, uint nHeight)
    {
      uint pixelSize = nWidth * nHeight;
      switch (enType)
      {
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRBGG8:
        case MvGvspPixelType.PixelType_Gvsp_Mono8:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR8:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG8:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB8:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG8:
        case MvGvspPixelType.PixelType_Gvsp_BayerRBGG8:
          return pixelSize;
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
          return pixelSize * 3U / 2U;
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono10:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono12:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono16:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG12:
        case MvGvspPixelType.PixelType_Gvsp_HB_YUV422_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_YUV422_YUYV_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Mono10:
        case MvGvspPixelType.PixelType_Gvsp_Mono12:
        case MvGvspPixelType.PixelType_Gvsp_Mono16:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR10:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG10:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB10:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG10:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR12:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG12:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB12:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG12:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR16:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG16:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB16:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG16:
        case MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
        case MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
          return pixelSize * 2U;
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_A32:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_C32:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_A32f:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_C32f:
          return pixelSize * 4U;
        case MvGvspPixelType.PixelType_Gvsp_HB_RGB8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BGR8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_RGB8_Planar:
          return pixelSize * 3U;
        case MvGvspPixelType.PixelType_Gvsp_HB_RGBA8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BGRA8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_RGBA8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BGRA8_Packed:
          return pixelSize * 4U;
        case MvGvspPixelType.PixelType_Gvsp_HB_BGRA16_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_RGBA16_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_AB32f:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_AB32:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_AC32:
        case MvGvspPixelType.PixelType_Gvsp_RGBA16_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BGRA16_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_AC32f:
          return (uint) ((int) pixelSize * 2 * 4);
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_ABC32:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_ABC32f:
          return (uint) ((int) pixelSize * 3 * 4);
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_ABC16:
          return (uint) ((int) pixelSize * 3 * 2);
        default:
          return pixelSize * 3U;
      }
    }

    /// <summary>获取图像大小</summary>
    /// <param name="pcImageInfo">图像信息</param>
    /// <returns>返回图像大小</returns>
    public static uint GetPixelSize(CImage pcImageInfo)
    {
      uint pixelSize = pcImageInfo.Width >= ushort.MaxValue || pcImageInfo.Height >= ushort.MaxValue ? pcImageInfo.ExtendHeight * pcImageInfo.ExtendWidth : (uint) pcImageInfo.Width * (uint) pcImageInfo.Height;
      switch (pcImageInfo.PixelType)
      {
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG8:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRBGG8:
        case MvGvspPixelType.PixelType_Gvsp_Mono8:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR8:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG8:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB8:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG8:
        case MvGvspPixelType.PixelType_Gvsp_BayerRBGG8:
          return pixelSize;
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
          return pixelSize * 3U / 2U;
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono10:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono12:
        case MvGvspPixelType.PixelType_Gvsp_HB_Mono16:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG10:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGR12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerRG12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerGB12:
        case MvGvspPixelType.PixelType_Gvsp_HB_BayerBG12:
        case MvGvspPixelType.PixelType_Gvsp_HB_YUV422_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_YUV422_YUYV_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Mono10:
        case MvGvspPixelType.PixelType_Gvsp_Mono12:
        case MvGvspPixelType.PixelType_Gvsp_Mono16:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR10:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG10:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB10:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG10:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR12:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG12:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB12:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG12:
        case MvGvspPixelType.PixelType_Gvsp_BayerGR16:
        case MvGvspPixelType.PixelType_Gvsp_BayerRG16:
        case MvGvspPixelType.PixelType_Gvsp_BayerGB16:
        case MvGvspPixelType.PixelType_Gvsp_BayerBG16:
        case MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
        case MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
          return pixelSize * 2U;
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_A32:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_C32:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_A32f:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_C32f:
          return pixelSize * 4U;
        case MvGvspPixelType.PixelType_Gvsp_HB_RGB8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BGR8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_RGB8_Planar:
          return pixelSize * 3U;
        case MvGvspPixelType.PixelType_Gvsp_HB_RGBA8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_BGRA8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_RGBA8_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BGRA8_Packed:
          return pixelSize * 4U;
        case MvGvspPixelType.PixelType_Gvsp_HB_BGRA16_Packed:
        case MvGvspPixelType.PixelType_Gvsp_HB_RGBA16_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_AB32f:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_AB32:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_AC32:
        case MvGvspPixelType.PixelType_Gvsp_RGBA16_Packed:
        case MvGvspPixelType.PixelType_Gvsp_BGRA16_Packed:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_AC32f:
          return (uint) ((int) pixelSize * 2 * 4);
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_ABC32:
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_ABC32f:
          return (uint) ((int) pixelSize * 3 * 4);
        case MvGvspPixelType.PixelType_Gvsp_Coord3D_ABC16:
          return (uint) ((int) pixelSize * 3 * 2);
        default:
          return pixelSize * 3U;
      }
    }
  }
}
