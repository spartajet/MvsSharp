// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CGenTLDevInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Text;

namespace MvsSharp
{
  /// <summary>采集卡上的相机信息</summary>
  public class CGenTLDevInfo : CCameraInfo
  {
    /// <summary>设备ID</summary>
    public string chDeviceID;
    /// <summary>设备版本</summary>
    public string chDeviceVersion;
    /// <summary>设备显示名</summary>
    public string chDisplayName;
    /// <summary>采集卡ID</summary>
    public string chInterfaceID;
    /// <summary>模型名</summary>
    public string chModelName;
    /// <summary>序列号</summary>
    public string chSerialNumber;
    /// <summary>传输类型</summary>
    public string chTLType;
    /// <summary>用户自定义名字</summary>
    public byte[] chUserDefinedName;
    /// <summary>Vendor名</summary>
    public string chVendorName;
    /// <summary>cti文件序号</summary>
    public uint nCtiIndex;

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
