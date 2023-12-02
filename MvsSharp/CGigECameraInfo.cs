// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CGigECameraInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Text;

namespace MvsSharp
{
  /// <summary>GigE相机信息</summary>
  public class CGigECameraInfo : CCameraInfo
  {
    /// <summary>支持的IP配置：bit31-static bit30-DHCP bit29-LLA</summary>
    public uint nIpCfgOption;
    /// <summary>当前IP配置</summary>
    public uint nIpCfgCurrent;
    /// <summary>当前IP</summary>
    public uint nCurrentIp;
    /// <summary>当前子网掩码</summary>
    public uint nCurrentSubNetMask;
    /// <summary>默认网关</summary>
    public uint nDefultGateWay;
    /// <summary>网卡IP</summary>
    public uint nNetExport;
    /// <summary>厂商名</summary>
    public string chManufacturerName;
    /// <summary>相机型号</summary>
    public string chModelName;
    /// <summary>相机版本</summary>
    public string chDeviceVersion;
    /// <summary>相机厂商信息</summary>
    public string chManufacturerSpecificInfo;
    /// <summary>相机序列号</summary>
    public string chSerialNumber;
    /// <summary>用户自定义名称</summary>
    public byte[] chUserDefinedName;
    /// <summary>设备主机ip</summary>
    public uint nHostIp;
    /// <summary>
    /// 设备类型
    /// 值为0:普通设备 值为1:虚拟采集卡上的设备 值为2:自研网卡上的设备
    /// </summary>
    public uint nDeviceType;
    /// <summary>组播ip</summary>
    public uint nMulticastIp;
    /// <summary>组播port</summary>
    public uint nMulticastPort;

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
