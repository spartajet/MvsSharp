// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CSystem
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Runtime.InteropServices;
using MvsSharp.CameraParams;

namespace MvsSharp
{
  /// <summary>系统枚举类</summary>
  public class CSystem
  {
    /// <summary>未知设备类型 unchecked():发生溢出不抛出异常</summary>
    public const int MV_UNKNOW_DEVICE = 0;
    /// <summary>GigE设备</summary>
    public const int MV_GIGE_DEVICE = 1;
    /// <summary>1394-a/b设备</summary>
    public const int MV_1394_DEVICE = 2;
    /// <summary>USB设备</summary>
    public const int MV_USB_DEVICE = 4;
    /// <summary>CameraLink设备</summary>
    public const int MV_CAMERALINK_DEVICE = 8;
    /// <summary>虚拟GigE设备</summary>
    public const int MV_VIR_GIGE_DEVICE = 16;
    /// <summary>虚拟USB设备</summary>
    public const int MV_VIR_USB_DEVICE = 32;
    /// <summary>自研网卡下GigE设备</summary>
    public const int MV_GENTL_GIGE_DEVICE = 64;

    /// <summary>设置GIGE枚举超时时间，仅支持GigE协议，范围 0-  UINT_MAX</summary>
    /// <param name="nMilTimeout">超时时间(ms)，默认100ms</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    public static int GIGE_SetEnumDevTimeout(uint nMilTimeout) => CCamCtrlRef.MV_GIGE_SetEnumDevTimeout(nMilTimeout);

    /// <summary>设置GIGE枚举命令的回复包类型</summary>
    /// <param name="nMode">回复包类型（默认广播），0-单播，1-广播</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    public static int GIGE_SetDiscoveryMode(uint nMode) => CCamCtrlRef.MV_GIGE_SetDiscoveryMode(nMode);

    /// <summary>获取SDK版本信息</summary>
    /// <returns>返回版本号，如V4.1.0.2</returns>
    public static string GetSDKVersion()
    {
      byte[] bytes = BitConverter.GetBytes(CCamCtrlRef.MV_CC_GetSDKVersion());
      return "V" + bytes[3].ToString() + "." + bytes[2].ToString() + "." + bytes[1].ToString() + "." + bytes[0].ToString();
    }

    /// <summary>获取支持的传输层</summary>
    /// <returns>支持的传输层编号</returns>
    public static int EnumerateTls() => CCamCtrlRef.MV_CC_EnumerateTls();

    /// <summary>枚举设备</summary>
    /// <param name="nType">枚举传输层</param>
    /// <param name="ltCameraList">设备列表</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    public static int EnumDevices(uint nType, ref List<CCameraInfo> ltCameraList)
    {
      if (ltCameraList == null)
        return -2147483644;
      ltCameraList.Clear();
      MV_CC_DEVICE_INFO_LIST stDevList = new MV_CC_DEVICE_INFO_LIST();
      int num = CCamCtrlRef.MV_CC_EnumDevices(nType, ref stDevList);
      if (num != 0)
        return num;
      for (int index = 0; (long) index < (long) stDevList.nDeviceNum; ++index)
      {
        CCameraInfo ccameraInfo = new CCameraInfo();
        MV_CC_DEVICE_INFO structure = (MV_CC_DEVICE_INFO) Marshal.PtrToStructure(stDevList.pDeviceInfo[index], typeof (MV_CC_DEVICE_INFO));
        if (1U == structure.nTLayerType)
        {
          MV_GIGE_DEVICE_INFO mvGigeDeviceInfo = (MV_GIGE_DEVICE_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stGigEInfo, typeof (MV_GIGE_DEVICE_INFO));
          CGigECameraInfo cgigEcameraInfo = new CGigECameraInfo();
          cgigEcameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          cgigEcameraInfo.nMacAddrLow = structure.nMacAddrLow;
          cgigEcameraInfo.nMajorVer = structure.nMajorVer;
          cgigEcameraInfo.nMinorVer = structure.nMinorVer;
          cgigEcameraInfo.nTLayerType = structure.nTLayerType;
          cgigEcameraInfo.nIpCfgOption = mvGigeDeviceInfo.nIpCfgOption;
          cgigEcameraInfo.nIpCfgCurrent = mvGigeDeviceInfo.nIpCfgCurrent;
          cgigEcameraInfo.nCurrentIp = mvGigeDeviceInfo.nCurrentIp;
          cgigEcameraInfo.nCurrentSubNetMask = mvGigeDeviceInfo.nCurrentSubNetMask;
          cgigEcameraInfo.nDefultGateWay = mvGigeDeviceInfo.nDefultGateWay;
          cgigEcameraInfo.nNetExport = mvGigeDeviceInfo.nNetExport;
          cgigEcameraInfo.chManufacturerName = mvGigeDeviceInfo.chManufacturerName;
          cgigEcameraInfo.chModelName = mvGigeDeviceInfo.chModelName;
          cgigEcameraInfo.chDeviceVersion = mvGigeDeviceInfo.chDeviceVersion;
          cgigEcameraInfo.chManufacturerSpecificInfo = mvGigeDeviceInfo.chManufacturerSpecificInfo;
          cgigEcameraInfo.chSerialNumber = mvGigeDeviceInfo.chSerialNumber;
          cgigEcameraInfo.chUserDefinedName = mvGigeDeviceInfo.chUserDefinedName;
          cgigEcameraInfo.nHostIp = mvGigeDeviceInfo.nReserved[0];
          cgigEcameraInfo.nDeviceType = mvGigeDeviceInfo.nReserved[1];
          cgigEcameraInfo.nMulticastIp = mvGigeDeviceInfo.nReserved[2];
          cgigEcameraInfo.nMulticastPort = mvGigeDeviceInfo.nReserved[3];
          ccameraInfo = (CCameraInfo) cgigEcameraInfo;
        }
        else if (4U == structure.nTLayerType)
        {
          MV_USB3_DEVICE_INFO mvUsB3DeviceInfo = (MV_USB3_DEVICE_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stUsb3VInfo, typeof (MV_USB3_DEVICE_INFO));
          CUSBCameraInfo cusbCameraInfo = new CUSBCameraInfo();
          cusbCameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          cusbCameraInfo.nMacAddrLow = structure.nMacAddrLow;
          cusbCameraInfo.nMajorVer = structure.nMajorVer;
          cusbCameraInfo.nMinorVer = structure.nMinorVer;
          cusbCameraInfo.nTLayerType = structure.nTLayerType;
          cusbCameraInfo.CrtlInEndPoint = mvUsB3DeviceInfo.CrtlInEndPoint;
          cusbCameraInfo.CrtlOutEndPoint = mvUsB3DeviceInfo.CrtlOutEndPoint;
          cusbCameraInfo.StreamEndPoint = mvUsB3DeviceInfo.StreamEndPoint;
          cusbCameraInfo.EventEndPoint = mvUsB3DeviceInfo.EventEndPoint;
          cusbCameraInfo.idVendor = mvUsB3DeviceInfo.idVendor;
          cusbCameraInfo.idProduct = mvUsB3DeviceInfo.idProduct;
          cusbCameraInfo.nDeviceNumber = mvUsB3DeviceInfo.nDeviceNumber;
          cusbCameraInfo.chDeviceGUID = mvUsB3DeviceInfo.chDeviceGUID;
          cusbCameraInfo.chVendorName = mvUsB3DeviceInfo.chVendorName;
          cusbCameraInfo.chModelName = mvUsB3DeviceInfo.chModelName;
          cusbCameraInfo.chFamilyName = mvUsB3DeviceInfo.chFamilyName;
          cusbCameraInfo.chDeviceVersion = mvUsB3DeviceInfo.chDeviceVersion;
          cusbCameraInfo.chManufacturerName = mvUsB3DeviceInfo.chManufacturerName;
          cusbCameraInfo.chSerialNumber = mvUsB3DeviceInfo.chSerialNumber;
          cusbCameraInfo.chUserDefinedName = mvUsB3DeviceInfo.chUserDefinedName;
          cusbCameraInfo.nbcdUSB = mvUsB3DeviceInfo.nbcdUSB;
          cusbCameraInfo.nDeviceAddress = mvUsB3DeviceInfo.nDeviceAddress;
          cusbCameraInfo.nDeviceType = mvUsB3DeviceInfo.nReserved[1];
          ccameraInfo = (CCameraInfo) cusbCameraInfo;
        }
        else if (8U == structure.nTLayerType)
        {
          MV_CamL_DEV_INFO mvCamLDevInfo = (MV_CamL_DEV_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stCamLInfo, typeof (MV_CamL_DEV_INFO));
          CCamLCameraInfo ccamLcameraInfo = new CCamLCameraInfo();
          ccamLcameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          ccamLcameraInfo.nMacAddrLow = structure.nMacAddrLow;
          ccamLcameraInfo.nMajorVer = structure.nMajorVer;
          ccamLcameraInfo.nMinorVer = structure.nMinorVer;
          ccamLcameraInfo.nTLayerType = structure.nTLayerType;
          ccamLcameraInfo.chPortID = mvCamLDevInfo.chPortID;
          ccamLcameraInfo.chModelName = mvCamLDevInfo.chModelName;
          ccamLcameraInfo.chFamilyName = mvCamLDevInfo.chFamilyName;
          ccamLcameraInfo.chDeviceVersion = mvCamLDevInfo.chDeviceVersion;
          ccamLcameraInfo.chManufacturerName = mvCamLDevInfo.chManufacturerName;
          ccamLcameraInfo.chSerialNumber = mvCamLDevInfo.chSerialNumber;
          ccameraInfo = (CCameraInfo) ccamLcameraInfo;
        }
        ltCameraList.Add(ccameraInfo);
      }
      return 0;
    }

    /// <summary>枚举设备</summary>
    /// <param name="nType">枚举传输层</param>
    /// <returns>返回设备列表信息</returns>
    public static List<CCameraInfo> EnumDevices(uint nType)
    {
      List<CCameraInfo> ltCameraList = new List<CCameraInfo>();
      try
      {
        return CSystem.EnumDevices(nType, ref ltCameraList) != 0 ? (List<CCameraInfo>) null : ltCameraList;
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          throw new Exception("Exception caught:" + ex.InnerException.Message);
        return (List<CCameraInfo>) null;
      }
    }

    /// <summary>根据厂商名字枚举设备</summary>
    /// <param name="nType">枚举传输层</param>
    /// <param name="ltCameraList">设备列表</param>
    /// <param name="strManufacturerName">厂商名字</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    public static int EnumDevicesEx(
      uint nType,
      ref List<CCameraInfo> ltCameraList,
      string strManufacturerName)
    {
      if (ltCameraList == null)
        return -2147483644;
      ltCameraList.Clear();
      MV_CC_DEVICE_INFO_LIST stDevList = new MV_CC_DEVICE_INFO_LIST();
      int num = CCamCtrlRef.MV_CC_EnumDevicesEx(nType, ref stDevList, strManufacturerName);
      if (num != 0)
        return num;
      for (int index = 0; (long) index < (long) stDevList.nDeviceNum; ++index)
      {
        CCameraInfo ccameraInfo = new CCameraInfo();
        MV_CC_DEVICE_INFO structure = (MV_CC_DEVICE_INFO) Marshal.PtrToStructure(stDevList.pDeviceInfo[index], typeof (MV_CC_DEVICE_INFO));
        if (1U == structure.nTLayerType)
        {
          MV_GIGE_DEVICE_INFO mvGigeDeviceInfo = (MV_GIGE_DEVICE_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stGigEInfo, typeof (MV_GIGE_DEVICE_INFO));
          CGigECameraInfo cgigEcameraInfo = new CGigECameraInfo();
          cgigEcameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          cgigEcameraInfo.nMacAddrLow = structure.nMacAddrLow;
          cgigEcameraInfo.nMajorVer = structure.nMajorVer;
          cgigEcameraInfo.nMinorVer = structure.nMinorVer;
          cgigEcameraInfo.nTLayerType = structure.nTLayerType;
          cgigEcameraInfo.nIpCfgOption = mvGigeDeviceInfo.nIpCfgOption;
          cgigEcameraInfo.nIpCfgCurrent = mvGigeDeviceInfo.nIpCfgCurrent;
          cgigEcameraInfo.nCurrentIp = mvGigeDeviceInfo.nCurrentIp;
          cgigEcameraInfo.nCurrentSubNetMask = mvGigeDeviceInfo.nCurrentSubNetMask;
          cgigEcameraInfo.nDefultGateWay = mvGigeDeviceInfo.nDefultGateWay;
          cgigEcameraInfo.nNetExport = mvGigeDeviceInfo.nNetExport;
          cgigEcameraInfo.chManufacturerName = mvGigeDeviceInfo.chManufacturerName;
          cgigEcameraInfo.chModelName = mvGigeDeviceInfo.chModelName;
          cgigEcameraInfo.chDeviceVersion = mvGigeDeviceInfo.chDeviceVersion;
          cgigEcameraInfo.chManufacturerSpecificInfo = mvGigeDeviceInfo.chManufacturerSpecificInfo;
          cgigEcameraInfo.chSerialNumber = mvGigeDeviceInfo.chSerialNumber;
          cgigEcameraInfo.chUserDefinedName = mvGigeDeviceInfo.chUserDefinedName;
          cgigEcameraInfo.nHostIp = mvGigeDeviceInfo.nReserved[0];
          cgigEcameraInfo.nDeviceType = mvGigeDeviceInfo.nReserved[1];
          cgigEcameraInfo.nMulticastIp = mvGigeDeviceInfo.nReserved[2];
          cgigEcameraInfo.nMulticastPort = mvGigeDeviceInfo.nReserved[3];
          ccameraInfo = (CCameraInfo) cgigEcameraInfo;
        }
        else if (4U == structure.nTLayerType)
        {
          MV_USB3_DEVICE_INFO mvUsB3DeviceInfo = (MV_USB3_DEVICE_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stUsb3VInfo, typeof (MV_USB3_DEVICE_INFO));
          CUSBCameraInfo cusbCameraInfo = new CUSBCameraInfo();
          cusbCameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          cusbCameraInfo.nMacAddrLow = structure.nMacAddrLow;
          cusbCameraInfo.nMajorVer = structure.nMajorVer;
          cusbCameraInfo.nMinorVer = structure.nMinorVer;
          cusbCameraInfo.nTLayerType = structure.nTLayerType;
          cusbCameraInfo.CrtlInEndPoint = mvUsB3DeviceInfo.CrtlInEndPoint;
          cusbCameraInfo.CrtlOutEndPoint = mvUsB3DeviceInfo.CrtlOutEndPoint;
          cusbCameraInfo.StreamEndPoint = mvUsB3DeviceInfo.StreamEndPoint;
          cusbCameraInfo.EventEndPoint = mvUsB3DeviceInfo.EventEndPoint;
          cusbCameraInfo.idVendor = mvUsB3DeviceInfo.idVendor;
          cusbCameraInfo.idProduct = mvUsB3DeviceInfo.idProduct;
          cusbCameraInfo.nDeviceNumber = mvUsB3DeviceInfo.nDeviceNumber;
          cusbCameraInfo.chDeviceGUID = mvUsB3DeviceInfo.chDeviceGUID;
          cusbCameraInfo.chVendorName = mvUsB3DeviceInfo.chVendorName;
          cusbCameraInfo.chModelName = mvUsB3DeviceInfo.chModelName;
          cusbCameraInfo.chFamilyName = mvUsB3DeviceInfo.chFamilyName;
          cusbCameraInfo.chDeviceVersion = mvUsB3DeviceInfo.chDeviceVersion;
          cusbCameraInfo.chManufacturerName = mvUsB3DeviceInfo.chManufacturerName;
          cusbCameraInfo.chSerialNumber = mvUsB3DeviceInfo.chSerialNumber;
          cusbCameraInfo.chUserDefinedName = mvUsB3DeviceInfo.chUserDefinedName;
          cusbCameraInfo.nbcdUSB = mvUsB3DeviceInfo.nbcdUSB;
          cusbCameraInfo.nDeviceAddress = mvUsB3DeviceInfo.nDeviceAddress;
          cusbCameraInfo.nDeviceType = mvUsB3DeviceInfo.nReserved[1];
          ccameraInfo = (CCameraInfo) cusbCameraInfo;
        }
        else if (8U == structure.nTLayerType)
        {
          MV_CamL_DEV_INFO mvCamLDevInfo = (MV_CamL_DEV_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stCamLInfo, typeof (MV_CamL_DEV_INFO));
          CCamLCameraInfo ccamLcameraInfo = new CCamLCameraInfo();
          ccamLcameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          ccamLcameraInfo.nMacAddrLow = structure.nMacAddrLow;
          ccamLcameraInfo.nMajorVer = structure.nMajorVer;
          ccamLcameraInfo.nMinorVer = structure.nMinorVer;
          ccamLcameraInfo.nTLayerType = structure.nTLayerType;
          ccamLcameraInfo.chPortID = mvCamLDevInfo.chPortID;
          ccamLcameraInfo.chModelName = mvCamLDevInfo.chModelName;
          ccamLcameraInfo.chFamilyName = mvCamLDevInfo.chFamilyName;
          ccamLcameraInfo.chDeviceVersion = mvCamLDevInfo.chDeviceVersion;
          ccamLcameraInfo.chManufacturerName = mvCamLDevInfo.chManufacturerName;
          ccamLcameraInfo.chSerialNumber = mvCamLDevInfo.chSerialNumber;
          ccameraInfo = (CCameraInfo) ccamLcameraInfo;
        }
        ltCameraList.Add(ccameraInfo);
      }
      return 0;
    }

    /// <summary>根据厂商名字枚举设备</summary>
    /// <param name="nType">枚举传输层</param>
    /// <param name="strManufacturerName">厂商名字</param>
    /// <returns>返回设备列表信息</returns>
    public static List<CCameraInfo> EnumDevicesEx(uint nType, string strManufacturerName)
    {
      List<CCameraInfo> ltCameraList = new List<CCameraInfo>();
      try
      {
        return CSystem.EnumDevicesEx(nType, ref ltCameraList, strManufacturerName) != 0 ? (List<CCameraInfo>) null : ltCameraList;
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          throw new Exception("Exception caught:" + ex.InnerException.Message);
        return (List<CCameraInfo>) null;
      }
    }

    /// <summary>枚举设备扩展（可指定排序方式枚举、根据厂商名字过滤）</summary>
    /// <param name="nType">枚举传输层</param>
    /// <param name="ltCameraList">设备列表</param>
    /// <param name="strManufacturerName">厂商名字（可传NULL，即不过滤）</param>
    /// <param name="enSortMethod">排序方式</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    public static int EnumDevicesEx2(
      uint nType,
      ref List<CCameraInfo> ltCameraList,
      string strManufacturerName,
      MV_SORT_METHOD enSortMethod)
    {
      if (ltCameraList == null)
        return -2147483644;
      ltCameraList.Clear();
      MV_CC_DEVICE_INFO_LIST stDevList = new MV_CC_DEVICE_INFO_LIST();
      int num = CCamCtrlRef.MV_CC_EnumDevicesEx2(nType, ref stDevList, strManufacturerName, enSortMethod);
      if (num != 0)
        return num;
      for (int index = 0; (long) index < (long) stDevList.nDeviceNum; ++index)
      {
        CCameraInfo ccameraInfo = new CCameraInfo();
        MV_CC_DEVICE_INFO structure = (MV_CC_DEVICE_INFO) Marshal.PtrToStructure(stDevList.pDeviceInfo[index], typeof (MV_CC_DEVICE_INFO));
        if (1U == structure.nTLayerType || 64U == structure.nTLayerType || 16U == structure.nTLayerType)
        {
          MV_GIGE_DEVICE_INFO mvGigeDeviceInfo = (MV_GIGE_DEVICE_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stGigEInfo, typeof (MV_GIGE_DEVICE_INFO));
          CGigECameraInfo cgigEcameraInfo = new CGigECameraInfo();
          cgigEcameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          cgigEcameraInfo.nMacAddrLow = structure.nMacAddrLow;
          cgigEcameraInfo.nMajorVer = structure.nMajorVer;
          cgigEcameraInfo.nMinorVer = structure.nMinorVer;
          cgigEcameraInfo.nTLayerType = structure.nTLayerType;
          cgigEcameraInfo.nIpCfgOption = mvGigeDeviceInfo.nIpCfgOption;
          cgigEcameraInfo.nIpCfgCurrent = mvGigeDeviceInfo.nIpCfgCurrent;
          cgigEcameraInfo.nCurrentIp = mvGigeDeviceInfo.nCurrentIp;
          cgigEcameraInfo.nCurrentSubNetMask = mvGigeDeviceInfo.nCurrentSubNetMask;
          cgigEcameraInfo.nDefultGateWay = mvGigeDeviceInfo.nDefultGateWay;
          cgigEcameraInfo.nNetExport = mvGigeDeviceInfo.nNetExport;
          cgigEcameraInfo.chManufacturerName = mvGigeDeviceInfo.chManufacturerName;
          cgigEcameraInfo.chModelName = mvGigeDeviceInfo.chModelName;
          cgigEcameraInfo.chDeviceVersion = mvGigeDeviceInfo.chDeviceVersion;
          cgigEcameraInfo.chManufacturerSpecificInfo = mvGigeDeviceInfo.chManufacturerSpecificInfo;
          cgigEcameraInfo.chSerialNumber = mvGigeDeviceInfo.chSerialNumber;
          cgigEcameraInfo.chUserDefinedName = mvGigeDeviceInfo.chUserDefinedName;
          cgigEcameraInfo.nHostIp = mvGigeDeviceInfo.nReserved[0];
          cgigEcameraInfo.nDeviceType = mvGigeDeviceInfo.nReserved[1];
          cgigEcameraInfo.nMulticastIp = mvGigeDeviceInfo.nReserved[2];
          cgigEcameraInfo.nMulticastPort = mvGigeDeviceInfo.nReserved[3];
          ccameraInfo = (CCameraInfo) cgigEcameraInfo;
        }
        else if (4U == structure.nTLayerType || 32U == structure.nTLayerType)
        {
          MV_USB3_DEVICE_INFO mvUsB3DeviceInfo = (MV_USB3_DEVICE_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stUsb3VInfo, typeof (MV_USB3_DEVICE_INFO));
          CUSBCameraInfo cusbCameraInfo = new CUSBCameraInfo();
          cusbCameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          cusbCameraInfo.nMacAddrLow = structure.nMacAddrLow;
          cusbCameraInfo.nMajorVer = structure.nMajorVer;
          cusbCameraInfo.nMinorVer = structure.nMinorVer;
          cusbCameraInfo.nTLayerType = structure.nTLayerType;
          cusbCameraInfo.CrtlInEndPoint = mvUsB3DeviceInfo.CrtlInEndPoint;
          cusbCameraInfo.CrtlOutEndPoint = mvUsB3DeviceInfo.CrtlOutEndPoint;
          cusbCameraInfo.StreamEndPoint = mvUsB3DeviceInfo.StreamEndPoint;
          cusbCameraInfo.EventEndPoint = mvUsB3DeviceInfo.EventEndPoint;
          cusbCameraInfo.idVendor = mvUsB3DeviceInfo.idVendor;
          cusbCameraInfo.idProduct = mvUsB3DeviceInfo.idProduct;
          cusbCameraInfo.nDeviceNumber = mvUsB3DeviceInfo.nDeviceNumber;
          cusbCameraInfo.chDeviceGUID = mvUsB3DeviceInfo.chDeviceGUID;
          cusbCameraInfo.chVendorName = mvUsB3DeviceInfo.chVendorName;
          cusbCameraInfo.chModelName = mvUsB3DeviceInfo.chModelName;
          cusbCameraInfo.chFamilyName = mvUsB3DeviceInfo.chFamilyName;
          cusbCameraInfo.chDeviceVersion = mvUsB3DeviceInfo.chDeviceVersion;
          cusbCameraInfo.chManufacturerName = mvUsB3DeviceInfo.chManufacturerName;
          cusbCameraInfo.chSerialNumber = mvUsB3DeviceInfo.chSerialNumber;
          cusbCameraInfo.chUserDefinedName = mvUsB3DeviceInfo.chUserDefinedName;
          cusbCameraInfo.nbcdUSB = mvUsB3DeviceInfo.nbcdUSB;
          cusbCameraInfo.nDeviceAddress = mvUsB3DeviceInfo.nDeviceAddress;
          cusbCameraInfo.nDeviceType = mvUsB3DeviceInfo.nReserved[1];
          ccameraInfo = (CCameraInfo) cusbCameraInfo;
        }
        else if (8U == structure.nTLayerType)
        {
          MV_CamL_DEV_INFO mvCamLDevInfo = (MV_CamL_DEV_INFO) CInnerTool.ByteToStruct(structure.SpecialInfo.stCamLInfo, typeof (MV_CamL_DEV_INFO));
          CCamLCameraInfo ccamLcameraInfo = new CCamLCameraInfo();
          ccamLcameraInfo.nMacAddrHigh = structure.nMacAddrHigh;
          ccamLcameraInfo.nMacAddrLow = structure.nMacAddrLow;
          ccamLcameraInfo.nMajorVer = structure.nMajorVer;
          ccamLcameraInfo.nMinorVer = structure.nMinorVer;
          ccamLcameraInfo.nTLayerType = structure.nTLayerType;
          ccamLcameraInfo.chPortID = mvCamLDevInfo.chPortID;
          ccamLcameraInfo.chModelName = mvCamLDevInfo.chModelName;
          ccamLcameraInfo.chFamilyName = mvCamLDevInfo.chFamilyName;
          ccamLcameraInfo.chDeviceVersion = mvCamLDevInfo.chDeviceVersion;
          ccamLcameraInfo.chManufacturerName = mvCamLDevInfo.chManufacturerName;
          ccamLcameraInfo.chSerialNumber = mvCamLDevInfo.chSerialNumber;
          ccameraInfo = (CCameraInfo) ccamLcameraInfo;
        }
        ltCameraList.Add(ccameraInfo);
      }
      return 0;
    }

    /// <summary>枚举设备扩展（可指定排序方式枚举、根据厂商名字过滤）</summary>
    /// <param name="nType">枚举传输层</param>
    /// <param name="strManufacturerName">厂商名字（可传NULL，即不过滤）</param>
    /// <param name="enSortMethod">排序方式</param>
    /// <returns>返回设备列表信息</returns>
    public static List<CCameraInfo> EnumDevicesEx2(
      uint nType,
      string strManufacturerName,
      MV_SORT_METHOD enSortMethod)
    {
      List<CCameraInfo> ltCameraList = new List<CCameraInfo>();
      try
      {
        CSystem.EnumDevicesEx2(nType, ref ltCameraList, strManufacturerName, enSortMethod);
        return ltCameraList;
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          throw new Exception("Exception caught:" + ex.InnerException.Message);
        return ltCameraList;
      }
    }

    /// <summary>通过GenTL枚举Interfaces</summary>
    /// <param name="ltInterfaceList">Interfaces列表</param>
    /// <param name="strGenTLPath">GenTL的cti文件路径</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    public static int EnumInterfaceByGenTL(
      ref List<CGenTLIFInfo> ltInterfaceList,
      string strGenTLPath)
    {
      if (ltInterfaceList == null)
        return -2147483644;
      ltInterfaceList.Clear();
      MV_GENTL_IF_INFO_LIST pstIFInfoList = new MV_GENTL_IF_INFO_LIST();
      int num = CCamCtrlRef.MV_CC_EnumInterfacesByGenTL(ref pstIFInfoList, strGenTLPath);
      if (num != 0)
        return num;
      for (int index = 0; (long) index < (long) pstIFInfoList.nInterfaceNum; ++index)
      {
        MV_GENTL_IF_INFO structure = (MV_GENTL_IF_INFO) Marshal.PtrToStructure(pstIFInfoList.pIFInfo[index], typeof (MV_GENTL_IF_INFO));
        ltInterfaceList.Add(new CGenTLIFInfo()
        {
          chInterfaceID = structure.chInterfaceID,
          chTLType = structure.chTLType,
          chDisplayName = structure.chDisplayName,
          nCtiIndex = structure.nCtiIndex
        });
      }
      return 0;
    }

    /// <summary>通过GenTL枚举Interfaces</summary>
    /// <param name="strGenTLPath">GenTL的cti文件路径</param>
    /// <returns>返回Interfaces列表</returns>
    public static List<CGenTLIFInfo> EnumInterfaceByGenTL(string strGenTLPath)
    {
      List<CGenTLIFInfo> ltInterfaceList = new List<CGenTLIFInfo>();
      try
      {
        CSystem.EnumInterfaceByGenTL(ref ltInterfaceList, strGenTLPath);
        return ltInterfaceList;
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          throw new Exception("Exception caught:" + ex.InnerException.Message);
        return ltInterfaceList;
      }
    }

    /// <summary>通过GenTL Interface枚举设备</summary>
    /// <param name="pcIFInfo">Interface信息</param>
    /// <param name="ltCameraList">设备列表</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    public static int EnumCameraListByGenTL(
      ref CGenTLIFInfo pcIFInfo,
      ref List<CGenTLDevInfo> ltCameraList)
    {
      if (pcIFInfo == null || ltCameraList == null)
        return -2147483644;
      ltCameraList.Clear();
      MV_GENTL_IF_INFO stIFInfo = new MV_GENTL_IF_INFO();
      MV_GENTL_DEV_INFO_LIST pstDevList = new MV_GENTL_DEV_INFO_LIST();
      stIFInfo.chInterfaceID = pcIFInfo.chInterfaceID;
      stIFInfo.chTLType = pcIFInfo.chTLType;
      stIFInfo.chDisplayName = pcIFInfo.chDisplayName;
      stIFInfo.nCtiIndex = pcIFInfo.nCtiIndex;
      int num = CCamCtrlRef.MV_CC_EnumDevicesByGenTL(ref stIFInfo, ref pstDevList);
      if (num != 0)
        return num;
      for (int index = 0; (long) index < (long) pstDevList.nDeviceNum; ++index)
      {
        MV_GENTL_DEV_INFO structure = (MV_GENTL_DEV_INFO) Marshal.PtrToStructure(pstDevList.pDeviceInfo[index], typeof (MV_GENTL_DEV_INFO));
        ltCameraList.Add(new CGenTLDevInfo()
        {
          chDeviceID = structure.chDeviceID,
          chDeviceVersion = structure.chDeviceVersion,
          chDisplayName = structure.chDisplayName,
          chInterfaceID = structure.chInterfaceID,
          chModelName = structure.chModelName,
          chSerialNumber = structure.chSerialNumber,
          chTLType = structure.chTLType,
          chUserDefinedName = structure.chUserDefinedName,
          chVendorName = structure.chVendorName,
          nCtiIndex = structure.nCtiIndex
        });
      }
      return 0;
    }

    /// <summary>通过GenTL Interface枚举设备</summary>
    /// <param name="pcIFInfo">Interface信息</param>
    /// <returns>成功, 返回设备列表;</returns>
    public static List<CGenTLDevInfo> EnumCameraListByGenTL(ref CGenTLIFInfo pcIFInfo)
    {
      List<CGenTLDevInfo> ltCameraList = new List<CGenTLDevInfo>();
      try
      {
        CSystem.EnumCameraListByGenTL(ref pcIFInfo, ref ltCameraList);
        return ltCameraList;
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          throw new Exception("Exception caught:" + ex.InnerException.Message);
        return ltCameraList;
      }
    }

    /// <summary>设备是否可达</summary>
    /// <param name="pcDevInfo">设备信息</param>
    /// <param name="enAccessMode">访问权限</param>
    /// <returns>可达，返回true；不可达，返回false</returns>
    public static bool IsDeviceAccessible(ref CCameraInfo pcDevInfo, MV_ACCESS_MODE enAccessMode)
    {
      if (pcDevInfo == null)
        return false;
      MV_CC_DEVICE_INFO stDevInfo = new MV_CC_DEVICE_INFO(0U);
      if (1U == pcDevInfo.nTLayerType)
      {
        CGigECameraInfo cgigEcameraInfo = (CGigECameraInfo) pcDevInfo;
        stDevInfo.nMajorVer = cgigEcameraInfo.nMajorVer;
        stDevInfo.nMinorVer = cgigEcameraInfo.nMinorVer;
        stDevInfo.nMacAddrHigh = cgigEcameraInfo.nMacAddrHigh;
        stDevInfo.nMacAddrLow = cgigEcameraInfo.nMacAddrLow;
        stDevInfo.nTLayerType = cgigEcameraInfo.nTLayerType;
        MV_GIGE_DEVICE_INFO mvGigeDeviceInfo = new MV_GIGE_DEVICE_INFO();
        mvGigeDeviceInfo.chDeviceVersion = cgigEcameraInfo.chDeviceVersion;
        mvGigeDeviceInfo.chManufacturerName = cgigEcameraInfo.chManufacturerName;
        mvGigeDeviceInfo.chManufacturerSpecificInfo = cgigEcameraInfo.chManufacturerSpecificInfo;
        mvGigeDeviceInfo.chModelName = cgigEcameraInfo.chModelName;
        mvGigeDeviceInfo.chSerialNumber = cgigEcameraInfo.chSerialNumber;
        mvGigeDeviceInfo.chUserDefinedName = cgigEcameraInfo.chUserDefinedName;
        mvGigeDeviceInfo.nCurrentIp = cgigEcameraInfo.nCurrentIp;
        mvGigeDeviceInfo.nCurrentSubNetMask = cgigEcameraInfo.nCurrentSubNetMask;
        mvGigeDeviceInfo.nDefultGateWay = cgigEcameraInfo.nDefultGateWay;
        mvGigeDeviceInfo.nIpCfgCurrent = cgigEcameraInfo.nIpCfgCurrent;
        mvGigeDeviceInfo.nIpCfgOption = cgigEcameraInfo.nIpCfgOption;
        mvGigeDeviceInfo.nNetExport = cgigEcameraInfo.nNetExport;
        if (mvGigeDeviceInfo.nReserved == null)
          mvGigeDeviceInfo.nReserved = new uint[4];
        mvGigeDeviceInfo.nReserved[0] = cgigEcameraInfo.nHostIp;
        mvGigeDeviceInfo.nReserved[1] = cgigEcameraInfo.nDeviceType;
        mvGigeDeviceInfo.nReserved[2] = cgigEcameraInfo.nMulticastIp;
        mvGigeDeviceInfo.nReserved[3] = cgigEcameraInfo.nMulticastPort;
        CInnerTool.StructToBytes<MV_GIGE_DEVICE_INFO>(mvGigeDeviceInfo, stDevInfo.SpecialInfo.stGigEInfo);
      }
      else if (4U == pcDevInfo.nTLayerType)
      {
        CUSBCameraInfo cusbCameraInfo = (CUSBCameraInfo) pcDevInfo;
        stDevInfo.nMajorVer = cusbCameraInfo.nMajorVer;
        stDevInfo.nMinorVer = cusbCameraInfo.nMinorVer;
        stDevInfo.nMacAddrHigh = cusbCameraInfo.nMacAddrHigh;
        stDevInfo.nMacAddrLow = cusbCameraInfo.nMacAddrLow;
        stDevInfo.nTLayerType = cusbCameraInfo.nTLayerType;
        MV_USB3_DEVICE_INFO mvUsB3DeviceInfo = new MV_USB3_DEVICE_INFO();
        mvUsB3DeviceInfo.chDeviceGUID = cusbCameraInfo.chDeviceGUID;
        mvUsB3DeviceInfo.chDeviceVersion = cusbCameraInfo.chDeviceVersion;
        mvUsB3DeviceInfo.chFamilyName = cusbCameraInfo.chFamilyName;
        mvUsB3DeviceInfo.chManufacturerName = cusbCameraInfo.chManufacturerName;
        mvUsB3DeviceInfo.chModelName = cusbCameraInfo.chModelName;
        mvUsB3DeviceInfo.chSerialNumber = cusbCameraInfo.chSerialNumber;
        mvUsB3DeviceInfo.chUserDefinedName = cusbCameraInfo.chUserDefinedName;
        mvUsB3DeviceInfo.chVendorName = cusbCameraInfo.chVendorName;
        mvUsB3DeviceInfo.CrtlInEndPoint = cusbCameraInfo.CrtlInEndPoint;
        mvUsB3DeviceInfo.CrtlOutEndPoint = cusbCameraInfo.CrtlOutEndPoint;
        mvUsB3DeviceInfo.EventEndPoint = cusbCameraInfo.EventEndPoint;
        mvUsB3DeviceInfo.idProduct = cusbCameraInfo.idProduct;
        mvUsB3DeviceInfo.idVendor = cusbCameraInfo.idVendor;
        mvUsB3DeviceInfo.nbcdUSB = cusbCameraInfo.nbcdUSB;
        mvUsB3DeviceInfo.nDeviceNumber = cusbCameraInfo.nDeviceNumber;
        mvUsB3DeviceInfo.StreamEndPoint = cusbCameraInfo.StreamEndPoint;
        if (mvUsB3DeviceInfo.nReserved == null)
          mvUsB3DeviceInfo.nReserved = new uint[2];
        mvUsB3DeviceInfo.nReserved[1] = cusbCameraInfo.nDeviceType;
        CInnerTool.StructToBytes<MV_USB3_DEVICE_INFO>(mvUsB3DeviceInfo, stDevInfo.SpecialInfo.stUsb3VInfo);
      }
      else
      {
        if (8U != pcDevInfo.nTLayerType)
          return false;
        CCamLCameraInfo ccamLcameraInfo = (CCamLCameraInfo) pcDevInfo;
        stDevInfo.nMajorVer = ccamLcameraInfo.nMajorVer;
        stDevInfo.nMinorVer = ccamLcameraInfo.nMinorVer;
        stDevInfo.nMacAddrHigh = ccamLcameraInfo.nMacAddrHigh;
        stDevInfo.nMacAddrLow = ccamLcameraInfo.nMacAddrLow;
        stDevInfo.nTLayerType = ccamLcameraInfo.nTLayerType;
        CInnerTool.StructToBytes<MV_CamL_DEV_INFO>(new MV_CamL_DEV_INFO()
        {
          chDeviceVersion = ccamLcameraInfo.chDeviceVersion,
          chFamilyName = ccamLcameraInfo.chFamilyName,
          chManufacturerName = ccamLcameraInfo.chManufacturerName,
          chModelName = ccamLcameraInfo.chModelName,
          chPortID = ccamLcameraInfo.chPortID,
          chSerialNumber = ccamLcameraInfo.chSerialNumber
        }, stDevInfo.SpecialInfo.stCamLInfo);
      }
      return CCamCtrlRef.MV_CC_IsDeviceAccessible(ref stDevInfo, (uint) enAccessMode);
    }
  }
}
