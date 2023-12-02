// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CUSBCameraInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Text;

namespace MvsSharp
{
  /// <summary>USB相机信息</summary>
  public class CUSBCameraInfo : CCameraInfo
  {
    /// <summary>支持的USB协议</summary>
    public uint nbcdUSB;
    /// <summary>控制输入端点</summary>
    public byte CrtlInEndPoint;
    /// <summary>控制输出端点</summary>
    public byte CrtlOutEndPoint;
    /// <summary>流端点</summary>
    public byte StreamEndPoint;
    /// <summary>事件端点</summary>
    public byte EventEndPoint;
    /// <summary>供应商ID号</summary>
    public ushort idVendor;
    /// <summary>产品ID号</summary>
    public ushort idProduct;
    /// <summary>设备索引号</summary>
    public uint nDeviceNumber;
    /// <summary>设备GUID号</summary>
    public string chDeviceGUID;
    /// <summary>供应商名字</summary>
    public string chVendorName;
    /// <summary>型号名字</summary>
    public string chModelName;
    /// <summary>家族名字</summary>
    public string chFamilyName;
    /// <summary>设备版本号</summary>
    public string chDeviceVersion;
    /// <summary>制造商名字</summary>
    public string chManufacturerName;
    /// <summary>序列号</summary>
    public string chSerialNumber;
    /// <summary>用户自定义名字</summary>
    public byte[] chUserDefinedName;
    /// <summary>设备地址</summary>
    public uint nDeviceAddress;
    /// <summary>
    /// 设备类型
    /// 值为0:普通设备 值为1:虚拟采集卡上的设备
    /// </summary>
    public uint nDeviceType;

    /// <summary>获取转码后的用户自定义名称</summary>
    public string UserDefinedName
    {
      get
      {
        byte[] numArray = CInnerTool.BytesTrimEnd(this.chUserDefinedName);
        return this.IsTextUTF8(numArray) ? Encoding.UTF8.GetString(numArray).TrimEnd(new char[1]) : Encoding.Default.GetString(numArray).TrimEnd(new char[1]);
      }
    }
  }
}
