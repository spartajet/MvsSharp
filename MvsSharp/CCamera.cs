// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CCamera
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using MvsSharp.CameraParams;

namespace MvsSharp
{
  /// <summary>相机控制类</summary>
  public class CCamera : 
    IParameter,
    IStreamGrabber,
    IImageProcess,
    IAddition,
    IGigeDevice,
    IDevice,
    IU3VDevice,
    ICamlDevice,
    IGenTLDevice
  {
    /// <summary>设备句柄</summary>
    private IntPtr handle;
    /// <summary>设备信息(型号+序列号)</summary>
    private string strCameraInfo;
    private Stopwatch stopwatch = new Stopwatch();

    /// <summary>内存拷贝</summary>
    /// <param name="dest">目标缓存</param>
    /// <param name="src">源缓存</param>
    /// <param name="count">拷贝大小</param>
    [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
    private static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

    /// <summary>Constructor</summary>
    public CCamera() => this.handle = IntPtr.Zero;

    /// <summary>Destructor</summary>
    ~CCamera()
    {
    }

    /// <summary>Get Camera Handle</summary>
    /// <returns></returns>
    public IntPtr GetCameraHandle() => this.handle;

    /// <summary>Create Handle</summary>
    /// <param name="pcDevInfo">Device Info Object</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int CreateHandle(ref CCameraInfo pcDevInfo)
    {
      if (pcDevInfo == null)
        return -2147483644;
      if (IntPtr.Zero != this.handle)
      {
        this.DestroyHandle();
        this.handle = IntPtr.Zero;
      }
      MV_CC_DEVICE_INFO stDevInfo = new MV_CC_DEVICE_INFO(0U);
      if (1U == pcDevInfo.nTLayerType || 64U == pcDevInfo.nTLayerType || 16U == pcDevInfo.nTLayerType)
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
        this.strCameraInfo = string.Format("DevID:{0}({1})", (object) cgigEcameraInfo.chModelName, (object) cgigEcameraInfo.chSerialNumber);
      }
      else if (4U == pcDevInfo.nTLayerType || 32U == pcDevInfo.nTLayerType)
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
        mvUsB3DeviceInfo.nDeviceAddress = cusbCameraInfo.nDeviceAddress;
        if (mvUsB3DeviceInfo.nReserved == null)
          mvUsB3DeviceInfo.nReserved = new uint[2];
        mvUsB3DeviceInfo.nReserved[1] = cusbCameraInfo.nDeviceType;
        CInnerTool.StructToBytes<MV_USB3_DEVICE_INFO>(mvUsB3DeviceInfo, stDevInfo.SpecialInfo.stUsb3VInfo);
        this.strCameraInfo = string.Format("DevID:{0}({1})", (object) cusbCameraInfo.chModelName, (object) cusbCameraInfo.chSerialNumber);
      }
      else
      {
        if (8U != pcDevInfo.nTLayerType)
          return -2147483644;
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
        this.strCameraInfo = string.Format("DevID:{0}({1})", (object) ccamLcameraInfo.chModelName, (object) ccamLcameraInfo.chSerialNumber);
      }
      return CCamCtrlRef.MV_CC_CreateHandle(ref this.handle, ref stDevInfo);
    }

    /// <summary>Create Device without log</summary>
    /// <param name="pcDevInfo">Device Information Object</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int CreateHandleWithoutLog(ref CCameraInfo pcDevInfo)
    {
      if (pcDevInfo == null)
        return -2147483644;
      if (IntPtr.Zero != this.handle)
      {
        this.DestroyHandle();
        this.handle = IntPtr.Zero;
      }
      MV_CC_DEVICE_INFO stDevInfo = new MV_CC_DEVICE_INFO(0U);
      if (1U == pcDevInfo.nTLayerType || 64U == pcDevInfo.nTLayerType || 16U == pcDevInfo.nTLayerType)
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
        this.strCameraInfo = string.Format("DevID:{0}({1})", (object) cgigEcameraInfo.chModelName, (object) cgigEcameraInfo.chSerialNumber);
      }
      else if (4U == pcDevInfo.nTLayerType || 32U == pcDevInfo.nTLayerType)
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
        mvUsB3DeviceInfo.nDeviceAddress = cusbCameraInfo.nDeviceAddress;
        if (mvUsB3DeviceInfo.nReserved == null)
          mvUsB3DeviceInfo.nReserved = new uint[3];
        mvUsB3DeviceInfo.nReserved[1] = cusbCameraInfo.nDeviceType;
        CInnerTool.StructToBytes<MV_USB3_DEVICE_INFO>(mvUsB3DeviceInfo, stDevInfo.SpecialInfo.stUsb3VInfo);
        this.strCameraInfo = string.Format("DevID:{0}({1})", (object) cusbCameraInfo.chModelName, (object) cusbCameraInfo.chSerialNumber);
      }
      else
      {
        if (8U != pcDevInfo.nTLayerType)
          return -2147483644;
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
        this.strCameraInfo = string.Format("DevID:{0}({1})", (object) ccamLcameraInfo.chModelName, (object) ccamLcameraInfo.chSerialNumber);
      }
      return CCamCtrlRef.MV_CC_CreateHandleWithoutLog(ref this.handle, ref stDevInfo);
    }

    /// <summary>Destroy Handle</summary>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int DestroyHandle()
    {
      int num = CCamCtrlRef.MV_CC_DestroyHandle(this.handle);
      this.handle = IntPtr.Zero;
      return num;
    }

    /// <summary>Open Device</summary>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int OpenDevice() => this.OpenDevice(Convert.ToUInt32(1), Convert.ToUInt16(0));

    /// <summary>Open Device</summary>
    /// <param name="nAccessMode">Access Right</param>
    /// <param name="nSwitchoverKey">Switch key of access right</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int OpenDevice(uint nAccessMode, ushort nSwitchoverKey) => CCamCtrlRef.MV_CC_OpenDevice(this.handle, nAccessMode, nSwitchoverKey);

    /// <summary>Close Device</summary>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int CloseDevice() => CCamCtrlRef.MV_CC_CloseDevice(this.handle);

    /// <summary>Is the Device Connected</summary>
    /// <returns>Device is Connected, return true. Device is Disconnected, return false. </returns>
    public bool IsDeviceConnected() => CCamCtrlRef.MV_CC_IsDeviceConnected(this.handle);

    /// <summary>Register the image callback function</summary>
    /// <param name="cbOutput">Callback function pointer</param>
    /// <param name="pUser">User defined variable</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int RegisterImageCallBackEx(cbOutputExdelegate cbOutput, IntPtr pUser) => CCamCtrlRef.MV_CC_RegisterImageCallBackEx(this.handle, cbOutput, pUser);

    /// <summary>Register the RGB image callback function</summary>
    /// <param name="cbOutput">Callback function pointer</param>
    /// <param name="pUser">User defined variable</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int RegisterImageCallBackForRGB(cbOutputExdelegate cbOutput, IntPtr pUser) => CCamCtrlRef.MV_CC_RegisterImageCallBackForRGB(this.handle, cbOutput, pUser);

    /// <summary>Register the BGR image callback function</summary>
    /// <param name="cbOutput">Callback function pointer</param>
    /// <param name="pUser">User defined variable</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int RegisterImageCallBackForBGR(cbOutputExdelegate cbOutput, IntPtr pUser) => CCamCtrlRef.MV_CC_RegisterImageCallBackForBGR(this.handle, cbOutput, pUser);

    /// <summary>Get device information(Called before start grabbing)</summary>
    /// <param name="pcDevInfo">device information</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetDeviceInfo(ref CCameraInfo pcDevInfo)
    {
      MV_CC_DEVICE_INFO pstDevInfo = new MV_CC_DEVICE_INFO(0U);
      int deviceInfo = CCamCtrlRef.MV_CC_GetDeviceInfo(this.handle, ref pstDevInfo);
      if (deviceInfo != 0)
        return deviceInfo;
      if (1U == pstDevInfo.nTLayerType)
      {
        MV_GIGE_DEVICE_INFO mvGigeDeviceInfo = (MV_GIGE_DEVICE_INFO) CInnerTool.ByteToStruct(pstDevInfo.SpecialInfo.stGigEInfo, typeof (MV_GIGE_DEVICE_INFO));
        CGigECameraInfo cgigEcameraInfo = new CGigECameraInfo();
        cgigEcameraInfo.nMajorVer = pstDevInfo.nMajorVer;
        cgigEcameraInfo.nMinorVer = pstDevInfo.nMinorVer;
        cgigEcameraInfo.nMacAddrHigh = pstDevInfo.nMacAddrHigh;
        cgigEcameraInfo.nMacAddrLow = pstDevInfo.nMacAddrLow;
        cgigEcameraInfo.nTLayerType = pstDevInfo.nTLayerType;
        cgigEcameraInfo.chDeviceVersion = mvGigeDeviceInfo.chDeviceVersion;
        cgigEcameraInfo.chManufacturerName = mvGigeDeviceInfo.chManufacturerName;
        cgigEcameraInfo.chManufacturerSpecificInfo = mvGigeDeviceInfo.chManufacturerSpecificInfo;
        cgigEcameraInfo.chModelName = mvGigeDeviceInfo.chModelName;
        cgigEcameraInfo.chSerialNumber = mvGigeDeviceInfo.chSerialNumber;
        cgigEcameraInfo.chUserDefinedName = mvGigeDeviceInfo.chUserDefinedName;
        cgigEcameraInfo.nCurrentIp = mvGigeDeviceInfo.nCurrentIp;
        cgigEcameraInfo.nCurrentSubNetMask = mvGigeDeviceInfo.nCurrentSubNetMask;
        cgigEcameraInfo.nDefultGateWay = mvGigeDeviceInfo.nDefultGateWay;
        cgigEcameraInfo.nIpCfgCurrent = mvGigeDeviceInfo.nIpCfgCurrent;
        cgigEcameraInfo.nIpCfgOption = mvGigeDeviceInfo.nIpCfgOption;
        cgigEcameraInfo.nNetExport = mvGigeDeviceInfo.nNetExport;
        pcDevInfo = (CCameraInfo) cgigEcameraInfo;
      }
      else if (4U == pstDevInfo.nTLayerType)
      {
        MV_USB3_DEVICE_INFO mvUsB3DeviceInfo = (MV_USB3_DEVICE_INFO) CInnerTool.ByteToStruct(pstDevInfo.SpecialInfo.stUsb3VInfo, typeof (MV_USB3_DEVICE_INFO));
        CUSBCameraInfo cusbCameraInfo = new CUSBCameraInfo();
        cusbCameraInfo.nMajorVer = pstDevInfo.nMajorVer;
        cusbCameraInfo.nMinorVer = pstDevInfo.nMinorVer;
        cusbCameraInfo.nMacAddrHigh = pstDevInfo.nMacAddrHigh;
        cusbCameraInfo.nMacAddrLow = pstDevInfo.nMacAddrLow;
        cusbCameraInfo.nTLayerType = pstDevInfo.nTLayerType;
        cusbCameraInfo.chDeviceGUID = mvUsB3DeviceInfo.chDeviceGUID;
        cusbCameraInfo.chDeviceVersion = mvUsB3DeviceInfo.chDeviceVersion;
        cusbCameraInfo.chFamilyName = mvUsB3DeviceInfo.chFamilyName;
        cusbCameraInfo.chManufacturerName = mvUsB3DeviceInfo.chManufacturerName;
        cusbCameraInfo.chModelName = mvUsB3DeviceInfo.chModelName;
        cusbCameraInfo.chSerialNumber = mvUsB3DeviceInfo.chSerialNumber;
        cusbCameraInfo.chUserDefinedName = mvUsB3DeviceInfo.chUserDefinedName;
        cusbCameraInfo.chVendorName = mvUsB3DeviceInfo.chVendorName;
        cusbCameraInfo.CrtlInEndPoint = mvUsB3DeviceInfo.CrtlInEndPoint;
        cusbCameraInfo.CrtlOutEndPoint = mvUsB3DeviceInfo.CrtlOutEndPoint;
        cusbCameraInfo.EventEndPoint = mvUsB3DeviceInfo.EventEndPoint;
        cusbCameraInfo.idProduct = mvUsB3DeviceInfo.idProduct;
        cusbCameraInfo.idVendor = mvUsB3DeviceInfo.idVendor;
        cusbCameraInfo.nbcdUSB = mvUsB3DeviceInfo.nbcdUSB;
        cusbCameraInfo.nDeviceNumber = mvUsB3DeviceInfo.nDeviceNumber;
        cusbCameraInfo.StreamEndPoint = mvUsB3DeviceInfo.StreamEndPoint;
        pcDevInfo = (CCameraInfo) cusbCameraInfo;
      }
      else
      {
        if (8U != pstDevInfo.nTLayerType)
          return -2147483647;
        MV_CamL_DEV_INFO mvCamLDevInfo = (MV_CamL_DEV_INFO) CInnerTool.ByteToStruct(pstDevInfo.SpecialInfo.stCamLInfo, typeof (MV_CamL_DEV_INFO));
        CCamLCameraInfo ccamLcameraInfo = new CCamLCameraInfo();
        ccamLcameraInfo.nMajorVer = pstDevInfo.nMajorVer;
        ccamLcameraInfo.nMinorVer = pstDevInfo.nMinorVer;
        ccamLcameraInfo.nMacAddrHigh = pstDevInfo.nMacAddrHigh;
        ccamLcameraInfo.nMacAddrLow = pstDevInfo.nMacAddrLow;
        ccamLcameraInfo.nTLayerType = pstDevInfo.nTLayerType;
        ccamLcameraInfo.chDeviceVersion = mvCamLDevInfo.chDeviceVersion;
        ccamLcameraInfo.chFamilyName = mvCamLDevInfo.chFamilyName;
        ccamLcameraInfo.chManufacturerName = mvCamLDevInfo.chManufacturerName;
        ccamLcameraInfo.chModelName = mvCamLDevInfo.chModelName;
        ccamLcameraInfo.chPortID = mvCamLDevInfo.chPortID;
        ccamLcameraInfo.chSerialNumber = mvCamLDevInfo.chSerialNumber;
        pcDevInfo = (CCameraInfo) ccamLcameraInfo;
      }
      return 0;
    }

    /// <summary>Get various type of information</summary>
    /// <param name="pcMatchInfo">Various type of information</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetAllMatchInfo(ref CAllMatchInfo pcMatchInfo)
    {
      if (pcMatchInfo == null)
        return -2147483644;
      MV_ALL_MATCH_INFO pstInfo = new MV_ALL_MATCH_INFO();
      int allMatchInfo = CCamCtrlRef.MV_CC_GetAllMatchInfo(this.handle, ref pstInfo);
      if (allMatchInfo != 0)
        return allMatchInfo;
      pcMatchInfo.InfoSize = pstInfo.nInfoSize;
      pcMatchInfo.Type = (MV_MATCH_TYPE) pstInfo.nType;
      pcMatchInfo.Info = pstInfo.pInfo;
      return 0;
    }

    /// <summary>
    /// Get the number of valid images in the current image buffer
    /// </summary>
    /// <param name="pnValidImageNum">The number of valid images in the current image buffer</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetValidImageNum(ref uint pnValidImageNum) => CCamCtrlRef.MV_CC_GetValidImageNum(this.handle, ref pnValidImageNum);

    /// <summary>Get Integer value</summary>
    /// <param name="strKey">Key value, for example, using "Width" to get width</param>
    /// <param name="oValue">Value of device features</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetIntValue(string strKey, ref CIntValue oValue)
    {
      if (oValue == null)
        return -2147483644;
      MVCC_INTVALUE_EX pIntValue = new MVCC_INTVALUE_EX();
      int intValueEx = CCamCtrlRef.MV_CC_GetIntValueEx(this.handle, strKey, ref pIntValue);
      if (intValueEx != 0)
        return intValueEx;
      oValue.CurValue = pIntValue.nCurValue;
      oValue.Inc = pIntValue.nInc;
      oValue.Max = pIntValue.nMax;
      oValue.Min = pIntValue.nMin;
      return 0;
    }

    /// <summary>Set Integer value</summary>
    /// <param name="strKey">Key value, for example, using "Width" to set width</param>
    /// <param name="nValue">Feature value to set</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetIntValue(string strKey, long nValue) => CCamCtrlRef.MV_CC_SetIntValueEx(this.handle, strKey, nValue);

    /// <summary>
    /// Get the symbolic of the specified value of the Enum type node
    /// </summary>
    /// <param name="strKey">Key value, for example, using "PixelFormat" to set pixel format</param>
    /// <param name="pcEnumEntry">Symbolic to get</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetEnumEntrySymbolic(string strKey, ref CEnumEntry pcEnumEntry)
    {
      if (pcEnumEntry == null)
        return -2147483644;
      MVCC_ENUMENTRY pstEnumEntry = new MVCC_ENUMENTRY();
      pstEnumEntry.nValue = pcEnumEntry.Value;
      int enumEntrySymbolic = CCamCtrlRef.MV_CC_GetEnumEntrySymbolic(this.handle, strKey, ref pstEnumEntry);
      if (enumEntrySymbolic != 0)
        return enumEntrySymbolic;
      pcEnumEntry.Symbolic = pstEnumEntry.chSymbolic;
      return 0;
    }

    /// <summary>Get Enum value</summary>
    /// <param name="strKey">Key value, for example, using "PixelFormat" to get pixel format</param>
    /// <param name="oValue">Value of device features</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetEnumValue(string strKey, ref CEnumValue oValue)
    {
      if (oValue == null)
        return -2147483644;
      MVCC_ENUMVALUE pEnumValue = new MVCC_ENUMVALUE();
      int enumValue = CCamCtrlRef.MV_CC_GetEnumValue(this.handle, strKey, ref pEnumValue);
      if (enumValue != 0)
        return enumValue;
      oValue.CurValue = pEnumValue.nCurValue;
      oValue.SupportedNum = pEnumValue.nSupportedNum;
      oValue.SupportValue = pEnumValue.nSupportValue;
      return 0;
    }

    /// <summary>Set Enum value</summary>
    /// <param name="strKey">Key value, for example, using "PixelFormat" to set pixel format</param>
    /// <param name="nValue">Feature value to set</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetEnumValue(string strKey, uint nValue) => CCamCtrlRef.MV_CC_SetEnumValue(this.handle, strKey, nValue);

    /// <summary>Set Enum value</summary>
    /// <param name="strKey">Key value, for example, using "PixelFormat" to set pixel format</param>
    /// <param name="sValue">Feature String to set</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetEnumValueByString(string strKey, string sValue) => CCamCtrlRef.MV_CC_SetEnumValueByString(this.handle, strKey, sValue);

    /// <summary>Get Float value</summary>
    /// <param name="strKey">Key value</param>
    /// <param name="oValue">Value of device features</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetFloatValue(string strKey, ref CFloatValue oValue)
    {
      if (oValue == null)
        return -2147483644;
      MVCC_FLOATVALUE pFloatValue = new MVCC_FLOATVALUE();
      int floatValue = CCamCtrlRef.MV_CC_GetFloatValue(this.handle, strKey, ref pFloatValue);
      if (floatValue != 0)
        return floatValue;
      oValue.CurValue = pFloatValue.fCurValue;
      oValue.Max = pFloatValue.fMax;
      oValue.Min = pFloatValue.fMin;
      return 0;
    }

    /// <summary>Set float value</summary>
    /// <param name="strKey">Key value</param>
    /// <param name="fValue">Feature value to set</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetFloatValue(string strKey, float fValue) => CCamCtrlRef.MV_CC_SetFloatValue(this.handle, strKey, fValue);

    /// <summary>Get Boolean value</summary>
    /// <param name="strKey">Key value</param>
    /// <param name="pbValue">Value of device features</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetBoolValue(string strKey, ref bool pbValue) => CCamCtrlRef.MV_CC_GetBoolValue(this.handle, strKey, ref pbValue);

    /// <summary>Set Boolean value</summary>
    /// <param name="strKey">Key value</param>
    /// <param name="bValue">Feature value to set</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetBoolValue(string strKey, bool bValue) => CCamCtrlRef.MV_CC_SetBoolValue(this.handle, strKey, bValue);

    /// <summary>Get String value</summary>
    /// <param name="strKey">Key value</param>
    /// <param name="oValue">Value of device features</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetStringValue(string strKey, ref CStringValue oValue)
    {
      if (oValue == null)
        return -2147483644;
      MVCC_STRINGVALUE pStringValue = new MVCC_STRINGVALUE();
      int stringValue = CCamCtrlRef.MV_CC_GetStringValue(this.handle, strKey, ref pStringValue);
      if (stringValue != 0)
        return stringValue;
      oValue.MaxLength = pStringValue.nMaxLength;
      oValue.CurValue = pStringValue.chCurValue;
      return 0;
    }

    /// <summary>Set String value</summary>
    /// <param name="strKey">Key value</param>
    /// <param name="strValue">Feature value to set</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetStringValue(string strKey, string strValue) => CCamCtrlRef.MV_CC_SetStringValue(this.handle, strKey, strValue);

    /// <summary>Send Command</summary>
    /// <param name="strKey">Key value</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetCommandValue(string strKey) => CCamCtrlRef.MV_CC_SetCommandValue(this.handle, strKey);

    /// <summary>Invalidate GenICam Nodes</summary>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int InvalidateNodes() => CCamCtrlRef.MV_CC_InvalidateNodes(this.handle);

    /// <summary>Get camera feature tree XML</summary>
    /// <param name="pData">XML data receiving buffer</param>
    /// <param name="nDataSize">Buffer size</param>
    /// <param name="pnDataLen">Actual data length</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int XML_GetGenICamXML(IntPtr pData, uint nDataSize, ref uint pnDataLen) => CCamCtrlRef.MV_XML_GetGenICamXML(this.handle, pData, nDataSize, ref pnDataLen);

    /// <summary>Get Access mode of cur node</summary>
    /// <param name="pstrName">Name of node</param>
    /// <param name="pAccessMode">Access mode of the node</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int XML_GetNodeAccessMode(string pstrName, ref MV_XML_AccessMode pAccessMode) => CCamCtrlRef.MV_XML_GetNodeAccessMode(this.handle, pstrName, ref pAccessMode);

    /// <summary>Get Interface Type of cur node</summary>
    /// <param name="pstrName">Name of node</param>
    /// <param name="pInterfaceType">Interface Type of the node</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int XML_GetNodeInterfaceType(string pstrName, ref MV_XML_InterfaceType pInterfaceType) => CCamCtrlRef.MV_XML_GetNodeInterfaceType(this.handle, pstrName, ref pInterfaceType);

    /// <summary>Start Grabbing</summary>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int StartGrabbing() => CCamCtrlRef.MV_CC_StartGrabbing(this.handle);

    /// <summary>Stop Grabbing</summary>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int StopGrabbing() => CCamCtrlRef.MV_CC_StopGrabbing(this.handle);

    /// <summary>
    /// Get one frame of RGB image, this function is using query to get data
    /// query whether the internal cache has data, get data if there has, return error code if no data
    /// </summary>
    /// <param name="pData">Image data receiving buffer</param>
    /// <param name="nDataSize">Buffer size</param>
    /// <param name="pcFrameEx">Frame information</param>
    /// <param name="nMsec">Waiting timeout</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetImageForRGB(byte[] pData, uint nDataSize, ref CFrameoutEx pcFrameEx, int nMsec)
    {
      if (pData == null || pcFrameEx == null || (long) pData.Length != (long) nDataSize)
        return -2147483644;
      MV_FRAME_OUT_INFO_EX pFrameInfo = new MV_FRAME_OUT_INFO_EX();
      IntPtr pData1 = Marshal.UnsafeAddrOfPinnedArrayElement((Array) pData, 0);
      if (IntPtr.Zero == pData1)
        return -2147483644;
      int imageForRgb = CCamCtrlRef.MV_CC_GetImageForRGB(this.handle, pData1, nDataSize, ref pFrameInfo, nMsec);
      if (imageForRgb != 0)
        return imageForRgb;
      pcFrameEx.pcImageInfoEx.Width = pFrameInfo.nWidth;
      pcFrameEx.pcImageInfoEx.Height = pFrameInfo.nHeight;
      pcFrameEx.pcImageInfoEx.PixelType = pFrameInfo.enPixelType;
      pcFrameEx.pcImageInfoEx.FrameLen = pFrameInfo.nFrameLen;
      pcFrameEx.pcImageInfoEx.nExtendHeight = pFrameInfo.nExtendHeight;
      pcFrameEx.pcImageInfoEx.nExtendWidth = pFrameInfo.nExtendWidth;
      pcFrameEx.Chunk.ChunkHeight = pFrameInfo.nChunkHeight;
      pcFrameEx.Chunk.ChunkWidth = pFrameInfo.nChunkWidth;
      pcFrameEx.Chunk.UnparsedChunkNum = pFrameInfo.nUnparsedChunkNum;
      if (IntPtr.Zero != pFrameInfo.UnparsedChunkList.pUnparsedChunkContent)
      {
        MV_CHUNK_DATA_CONTENT structure = (MV_CHUNK_DATA_CONTENT) Marshal.PtrToStructure(pFrameInfo.UnparsedChunkList.pUnparsedChunkContent, typeof (MV_CHUNK_DATA_CONTENT));
        pcFrameEx.Chunk.ChunkDataContent.ChunkID = structure.nChunkID;
        pcFrameEx.Chunk.ChunkDataContent.ChunkLen = structure.nChunkLen;
        pcFrameEx.Chunk.ChunkDataContent.ChunkAddr = structure.pChunkData;
      }
      pcFrameEx.FrameSpec.ExposureTime = pFrameInfo.fExposureTime;
      pcFrameEx.FrameSpec.Gain = pFrameInfo.fGain;
      pcFrameEx.FrameSpec.AverageBrightness = pFrameInfo.nAverageBrightness;
      pcFrameEx.FrameSpec.Blue = pFrameInfo.nBlue;
      pcFrameEx.FrameSpec.HostTimeStamp = pFrameInfo.nHostTimeStamp;
      pcFrameEx.FrameSpec.Input = pFrameInfo.nInput;
      pcFrameEx.FrameSpec.LostPacket = pFrameInfo.nLostPacket;
      pcFrameEx.FrameSpec.OffsetX = pFrameInfo.nOffsetX;
      pcFrameEx.FrameSpec.OffsetY = pFrameInfo.nOffsetY;
      pcFrameEx.FrameSpec.Output = pFrameInfo.nOutput;
      pcFrameEx.FrameSpec.Red = pFrameInfo.nRed;
      pcFrameEx.FrameSpec.Green = pFrameInfo.nGreen;
      pcFrameEx.FrameSpec.SecondCount = pFrameInfo.nSecondCount;
      pcFrameEx.FrameSpec.TriggerIndex = pFrameInfo.nTriggerIndex;
      pcFrameEx.FrameSpec.CycleCount = pFrameInfo.nCycleCount;
      pcFrameEx.FrameSpec.CycleOffset = pFrameInfo.nCycleOffset;
      pcFrameEx.FrameSpec.DevTimeStampHigh = pFrameInfo.nDevTimeStampHigh;
      pcFrameEx.FrameSpec.DevTimeStampLow = pFrameInfo.nDevTimeStampLow;
      pcFrameEx.FrameSpec.FrameCounter = pFrameInfo.nFrameCounter;
      pcFrameEx.FrameSpec.FrameNum = pFrameInfo.nFrameNum;
      return 0;
    }

    /// <summary>
    /// Get one frame of BGR image, this function is using query to get data
    /// query whether the internal cache has data, get data if there has, return error code if no data
    /// </summary>
    /// <param name="pData">Image data receiving buffer</param>
    /// <param name="nDataSize">Buffer size</param>
    /// <param name="pcFrameEx">Image information</param>
    /// <param name="nMsec">Waiting timeout</param>
    /// <returns>Success, return MV_OK. Failure, return error cod</returns>
    public int GetImageForBGR(byte[] pData, uint nDataSize, ref CFrameoutEx pcFrameEx, int nMsec)
    {
      if (pData == null || pcFrameEx == null || (long) pData.Length != (long) nDataSize)
        return -2147483644;
      MV_FRAME_OUT_INFO_EX pFrameInfo = new MV_FRAME_OUT_INFO_EX();
      IntPtr pData1 = Marshal.UnsafeAddrOfPinnedArrayElement((Array) pData, 0);
      if (IntPtr.Zero == pData1)
        return -2147483644;
      int imageForBgr = CCamCtrlRef.MV_CC_GetImageForBGR(this.handle, pData1, nDataSize, ref pFrameInfo, nMsec);
      if (imageForBgr != 0)
        return imageForBgr;
      pcFrameEx.pcImageInfoEx.Width = pFrameInfo.nWidth;
      pcFrameEx.pcImageInfoEx.Height = pFrameInfo.nHeight;
      pcFrameEx.pcImageInfoEx.PixelType = pFrameInfo.enPixelType;
      pcFrameEx.pcImageInfoEx.FrameLen = pFrameInfo.nFrameLen;
      pcFrameEx.pcImageInfoEx.nExtendHeight = pFrameInfo.nExtendHeight;
      pcFrameEx.pcImageInfoEx.nExtendWidth = pFrameInfo.nExtendWidth;
      pcFrameEx.Chunk.ChunkHeight = pFrameInfo.nChunkHeight;
      pcFrameEx.Chunk.ChunkWidth = pFrameInfo.nChunkWidth;
      pcFrameEx.Chunk.UnparsedChunkNum = pFrameInfo.nUnparsedChunkNum;
      if (IntPtr.Zero != pFrameInfo.UnparsedChunkList.pUnparsedChunkContent)
      {
        MV_CHUNK_DATA_CONTENT structure = (MV_CHUNK_DATA_CONTENT) Marshal.PtrToStructure(pFrameInfo.UnparsedChunkList.pUnparsedChunkContent, typeof (MV_CHUNK_DATA_CONTENT));
        pcFrameEx.Chunk.ChunkDataContent.ChunkID = structure.nChunkID;
        pcFrameEx.Chunk.ChunkDataContent.ChunkLen = structure.nChunkLen;
        pcFrameEx.Chunk.ChunkDataContent.ChunkAddr = structure.pChunkData;
      }
      pcFrameEx.FrameSpec.ExposureTime = pFrameInfo.fExposureTime;
      pcFrameEx.FrameSpec.Gain = pFrameInfo.fGain;
      pcFrameEx.FrameSpec.AverageBrightness = pFrameInfo.nAverageBrightness;
      pcFrameEx.FrameSpec.Blue = pFrameInfo.nBlue;
      pcFrameEx.FrameSpec.HostTimeStamp = pFrameInfo.nHostTimeStamp;
      pcFrameEx.FrameSpec.Input = pFrameInfo.nInput;
      pcFrameEx.FrameSpec.LostPacket = pFrameInfo.nLostPacket;
      pcFrameEx.FrameSpec.OffsetX = pFrameInfo.nOffsetX;
      pcFrameEx.FrameSpec.OffsetY = pFrameInfo.nOffsetY;
      pcFrameEx.FrameSpec.Output = pFrameInfo.nOutput;
      pcFrameEx.FrameSpec.Red = pFrameInfo.nRed;
      pcFrameEx.FrameSpec.Green = pFrameInfo.nGreen;
      pcFrameEx.FrameSpec.SecondCount = pFrameInfo.nSecondCount;
      pcFrameEx.FrameSpec.TriggerIndex = pFrameInfo.nTriggerIndex;
      pcFrameEx.FrameSpec.CycleCount = pFrameInfo.nCycleCount;
      pcFrameEx.FrameSpec.CycleOffset = pFrameInfo.nCycleOffset;
      pcFrameEx.FrameSpec.DevTimeStampHigh = pFrameInfo.nDevTimeStampHigh;
      pcFrameEx.FrameSpec.DevTimeStampLow = pFrameInfo.nDevTimeStampLow;
      pcFrameEx.FrameSpec.FrameCounter = pFrameInfo.nFrameCounter;
      pcFrameEx.FrameSpec.FrameNum = pFrameInfo.nFrameNum;
      return 0;
    }

    /// <summary>Get a frame of an image using an internal cache</summary>
    /// <param name="pcFrame">Image data and image information</param>
    /// <param name="nMsec">Waiting timeout</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetImageBuffer(ref CFrameout pcFrame, int nMsec)
    {
      if (pcFrame == null)
        return -2147483644;
      this.stopwatch.Restart();
      MV_FRAME_OUT pFrame = new MV_FRAME_OUT();
      int imageBuffer = CCamCtrlRef.MV_CC_GetImageBuffer(this.handle, ref pFrame, nMsec);
      if (imageBuffer != 0)
        return imageBuffer;
      CImage cimage = new CImage(pFrame.pBufAddr, pFrame.stFrameInfo.enPixelType, pFrame.stFrameInfo.nFrameLen, pFrame.stFrameInfo.nHeight, pFrame.stFrameInfo.nWidth, pFrame.stFrameInfo.nExtendHeight, pFrame.stFrameInfo.nExtendWidth);
      pcFrame.Image = cimage;
      pcFrame.Chunk.ChunkHeight = pFrame.stFrameInfo.nChunkHeight;
      pcFrame.Chunk.ChunkWidth = pFrame.stFrameInfo.nChunkWidth;
      pcFrame.Chunk.UnparsedChunkNum = pFrame.stFrameInfo.nUnparsedChunkNum;
      if (IntPtr.Zero != pFrame.stFrameInfo.UnparsedChunkList.pUnparsedChunkContent)
      {
        MV_CHUNK_DATA_CONTENT structure = (MV_CHUNK_DATA_CONTENT) Marshal.PtrToStructure(pFrame.stFrameInfo.UnparsedChunkList.pUnparsedChunkContent, typeof (MV_CHUNK_DATA_CONTENT));
        pcFrame.Chunk.ChunkDataContent.ChunkID = structure.nChunkID;
        pcFrame.Chunk.ChunkDataContent.ChunkLen = structure.nChunkLen;
        pcFrame.Chunk.ChunkDataContent.ChunkAddr = structure.pChunkData;
      }
      pcFrame.FrameSpec.ExposureTime = pFrame.stFrameInfo.fExposureTime;
      pcFrame.FrameSpec.Gain = pFrame.stFrameInfo.fGain;
      pcFrame.FrameSpec.AverageBrightness = pFrame.stFrameInfo.nAverageBrightness;
      pcFrame.FrameSpec.Blue = pFrame.stFrameInfo.nBlue;
      pcFrame.FrameSpec.HostTimeStamp = pFrame.stFrameInfo.nHostTimeStamp;
      pcFrame.FrameSpec.Input = pFrame.stFrameInfo.nInput;
      pcFrame.FrameSpec.LostPacket = pFrame.stFrameInfo.nLostPacket;
      pcFrame.FrameSpec.OffsetX = pFrame.stFrameInfo.nOffsetX;
      pcFrame.FrameSpec.OffsetY = pFrame.stFrameInfo.nOffsetY;
      pcFrame.FrameSpec.Output = pFrame.stFrameInfo.nOutput;
      pcFrame.FrameSpec.Red = pFrame.stFrameInfo.nRed;
      pcFrame.FrameSpec.Green = pFrame.stFrameInfo.nGreen;
      pcFrame.FrameSpec.SecondCount = pFrame.stFrameInfo.nSecondCount;
      pcFrame.FrameSpec.TriggerIndex = pFrame.stFrameInfo.nTriggerIndex;
      pcFrame.FrameSpec.CycleCount = pFrame.stFrameInfo.nCycleCount;
      pcFrame.FrameSpec.CycleOffset = pFrame.stFrameInfo.nCycleOffset;
      pcFrame.FrameSpec.DevTimeStampHigh = pFrame.stFrameInfo.nDevTimeStampHigh;
      pcFrame.FrameSpec.DevTimeStampLow = pFrame.stFrameInfo.nDevTimeStampLow;
      pcFrame.FrameSpec.FrameCounter = pFrame.stFrameInfo.nFrameCounter;
      pcFrame.FrameSpec.FrameNum = pFrame.stFrameInfo.nFrameNum;
      this.stopwatch.Stop();
      return 0;
    }

    /// <summary>Free image buffer（used with MV_CC_GetImageBuffer）</summary>
    /// <param name="pcFrame">Image data and image information</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int FreeImageBuffer(ref CFrameout pcFrame)
    {
      string str1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff:ffffff");
      if (pcFrame == null)
        return -2147483644;
      CInnerTool.DebugInfo(this.strCameraInfo + string.Format("FreeImageBuffer start, FrameNum [{0}], CurTime{1}", (object) pcFrame.FrameSpec.FrameNum, (object) str1));
      this.stopwatch.Restart();
      MV_FRAME_OUT pFrame = new MV_FRAME_OUT();
      pFrame.pBufAddr = pcFrame.Image.ImageAddr;
      pFrame.stFrameInfo.enPixelType = pcFrame.Image.PixelType;
      pFrame.stFrameInfo.nHeight = pcFrame.Image.Height;
      pFrame.stFrameInfo.nWidth = pcFrame.Image.Width;
      pFrame.stFrameInfo.nFrameLen = pcFrame.Image.FrameLen;
      pFrame.stFrameInfo.nExtendHeight = pcFrame.Image.ExtendHeight;
      pFrame.stFrameInfo.nExtendWidth = pcFrame.Image.ExtendWidth;
      pFrame.stFrameInfo.nChunkHeight = pcFrame.Chunk.ChunkHeight;
      pFrame.stFrameInfo.nChunkWidth = pcFrame.Chunk.ChunkWidth;
      pFrame.stFrameInfo.nUnparsedChunkNum = pcFrame.Chunk.UnparsedChunkNum;
      MV_CHUNK_DATA_CONTENT structure = new MV_CHUNK_DATA_CONTENT();
      structure.nChunkID = pcFrame.Chunk.ChunkDataContent.ChunkID;
      structure.nChunkLen = pcFrame.Chunk.ChunkDataContent.ChunkLen;
      structure.pChunkData = pcFrame.Chunk.ChunkDataContent.ChunkAddr;
      pFrame.stFrameInfo.UnparsedChunkList.pUnparsedChunkContent = Marshal.AllocHGlobal(Marshal.SizeOf((object) structure));
      Marshal.StructureToPtr((object) structure, pFrame.stFrameInfo.UnparsedChunkList.pUnparsedChunkContent, false);
      pFrame.stFrameInfo.fExposureTime = pcFrame.FrameSpec.ExposureTime;
      pFrame.stFrameInfo.fGain = pcFrame.FrameSpec.Gain;
      pFrame.stFrameInfo.nAverageBrightness = pcFrame.FrameSpec.AverageBrightness;
      pFrame.stFrameInfo.nBlue = pcFrame.FrameSpec.Blue;
      pFrame.stFrameInfo.nCycleCount = pcFrame.FrameSpec.CycleCount;
      pFrame.stFrameInfo.nCycleOffset = pcFrame.FrameSpec.CycleOffset;
      pFrame.stFrameInfo.nDevTimeStampHigh = pcFrame.FrameSpec.DevTimeStampHigh;
      pFrame.stFrameInfo.nDevTimeStampLow = pcFrame.FrameSpec.DevTimeStampLow;
      pFrame.stFrameInfo.nFrameCounter = pcFrame.FrameSpec.FrameCounter;
      pFrame.stFrameInfo.nFrameNum = pcFrame.FrameSpec.FrameNum;
      pFrame.stFrameInfo.nGreen = pcFrame.FrameSpec.Green;
      pFrame.stFrameInfo.nHostTimeStamp = pcFrame.FrameSpec.HostTimeStamp;
      pFrame.stFrameInfo.nInput = pcFrame.FrameSpec.Input;
      pFrame.stFrameInfo.nLostPacket = pcFrame.FrameSpec.LostPacket;
      pFrame.stFrameInfo.nOffsetX = pcFrame.FrameSpec.OffsetX;
      pFrame.stFrameInfo.nOffsetY = pcFrame.FrameSpec.OffsetY;
      pFrame.stFrameInfo.nOutput = pcFrame.FrameSpec.Output;
      pFrame.stFrameInfo.nRed = pcFrame.FrameSpec.Red;
      pFrame.stFrameInfo.nSecondCount = pcFrame.FrameSpec.SecondCount;
      pFrame.stFrameInfo.nTriggerIndex = pcFrame.FrameSpec.TriggerIndex;
      int num = CCamCtrlRef.MV_CC_FreeImageBuffer(this.handle, ref pFrame);
      if (IntPtr.Zero != pFrame.stFrameInfo.UnparsedChunkList.pUnparsedChunkContent)
      {
        Marshal.FreeHGlobal(pFrame.stFrameInfo.UnparsedChunkList.pUnparsedChunkContent);
        pFrame.stFrameInfo.UnparsedChunkList.pUnparsedChunkContent = IntPtr.Zero;
      }
      this.stopwatch.Stop();
      string str2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff:ffffff");
      CInnerTool.DebugInfo(this.strCameraInfo + string.Format("Free ImageNum [{0}] Buffer end cost {1} ms, CurTime{2}", (object) pcFrame.FrameSpec.FrameNum, (object) this.stopwatch.ElapsedMilliseconds.ToString(), (object) str2));
      return num;
    }

    /// <summary>Get a frame of an image</summary>
    /// <param name="pData">Image data receiving buffer</param>
    /// <param name="nDataSize">Buffer size</param>
    /// <param name="pcFrameEx">Image information</param>
    /// <param name="nMsec">Waiting timeout</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetOneFrameTimeout(
      byte[] pData,
      uint nDataSize,
      ref CFrameoutEx pcFrameEx,
      int nMsec)
    {
      if (pData == null || pcFrameEx == null || (long) pData.Length != (long) nDataSize)
        return -2147483644;
      MV_FRAME_OUT_INFO_EX pFrameInfo = new MV_FRAME_OUT_INFO_EX();
      IntPtr pData1 = Marshal.UnsafeAddrOfPinnedArrayElement((Array) pData, 0);
      if (IntPtr.Zero == pData1)
        return -2147483644;
      int oneFrameTimeout = CCamCtrlRef.MV_CC_GetOneFrameTimeout(this.handle, pData1, nDataSize, ref pFrameInfo, nMsec);
      if (oneFrameTimeout != 0)
        return oneFrameTimeout;
      pcFrameEx.pcImageInfoEx.Width = pFrameInfo.nWidth;
      pcFrameEx.pcImageInfoEx.Height = pFrameInfo.nHeight;
      pcFrameEx.pcImageInfoEx.PixelType = pFrameInfo.enPixelType;
      pcFrameEx.pcImageInfoEx.FrameLen = pFrameInfo.nFrameLen;
      pcFrameEx.pcImageInfoEx.nExtendHeight = pFrameInfo.nExtendHeight;
      pcFrameEx.pcImageInfoEx.nExtendWidth = pFrameInfo.nExtendWidth;
      pcFrameEx.Chunk.ChunkHeight = pFrameInfo.nChunkHeight;
      pcFrameEx.Chunk.ChunkWidth = pFrameInfo.nChunkWidth;
      pcFrameEx.Chunk.UnparsedChunkNum = pFrameInfo.nUnparsedChunkNum;
      if (IntPtr.Zero != pFrameInfo.UnparsedChunkList.pUnparsedChunkContent)
      {
        MV_CHUNK_DATA_CONTENT structure = (MV_CHUNK_DATA_CONTENT) Marshal.PtrToStructure(pFrameInfo.UnparsedChunkList.pUnparsedChunkContent, typeof (MV_CHUNK_DATA_CONTENT));
        pcFrameEx.Chunk.ChunkDataContent.ChunkID = structure.nChunkID;
        pcFrameEx.Chunk.ChunkDataContent.ChunkLen = structure.nChunkLen;
        pcFrameEx.Chunk.ChunkDataContent.ChunkAddr = structure.pChunkData;
      }
      pcFrameEx.FrameSpec.ExposureTime = pFrameInfo.fExposureTime;
      pcFrameEx.FrameSpec.Gain = pFrameInfo.fGain;
      pcFrameEx.FrameSpec.AverageBrightness = pFrameInfo.nAverageBrightness;
      pcFrameEx.FrameSpec.Blue = pFrameInfo.nBlue;
      pcFrameEx.FrameSpec.HostTimeStamp = pFrameInfo.nHostTimeStamp;
      pcFrameEx.FrameSpec.Input = pFrameInfo.nInput;
      pcFrameEx.FrameSpec.LostPacket = pFrameInfo.nLostPacket;
      pcFrameEx.FrameSpec.OffsetX = pFrameInfo.nOffsetX;
      pcFrameEx.FrameSpec.OffsetY = pFrameInfo.nOffsetY;
      pcFrameEx.FrameSpec.Output = pFrameInfo.nOutput;
      pcFrameEx.FrameSpec.Red = pFrameInfo.nRed;
      pcFrameEx.FrameSpec.Green = pFrameInfo.nGreen;
      pcFrameEx.FrameSpec.SecondCount = pFrameInfo.nSecondCount;
      pcFrameEx.FrameSpec.TriggerIndex = pFrameInfo.nTriggerIndex;
      pcFrameEx.FrameSpec.CycleCount = pFrameInfo.nCycleCount;
      pcFrameEx.FrameSpec.CycleOffset = pFrameInfo.nCycleOffset;
      pcFrameEx.FrameSpec.DevTimeStampHigh = pFrameInfo.nDevTimeStampHigh;
      pcFrameEx.FrameSpec.DevTimeStampLow = pFrameInfo.nDevTimeStampLow;
      pcFrameEx.FrameSpec.FrameCounter = pFrameInfo.nFrameCounter;
      pcFrameEx.FrameSpec.FrameNum = pFrameInfo.nFrameNum;
      return 0;
    }

    /// <summary>Clear image Buffers to clear old data</summary>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int ClearImageBuffer() => CCamCtrlRef.MV_CC_ClearImageBuffer(this.handle);

    /// <summary>Display one frame image</summary>
    /// <param name="pcDisplayInfo">Image information</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int DisplayOneFrame(ref CDisplayFrameInfo pcDisplayInfo)
    {
      if (pcDisplayInfo == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_DisplayOneFrame(this.handle, ref new MV_DISPLAY_FRAME_INFO()
      {
        enPixelType = pcDisplayInfo.Image.PixelType,
        hWnd = pcDisplayInfo.WindowHandle,
        nDataLen = pcDisplayInfo.Image.FrameLen,
        nHeight = pcDisplayInfo.Image.Height,
        nWidth = pcDisplayInfo.Image.Width,
        pData = pcDisplayInfo.Image.ImageAddr
      });
    }

    /// <summary>
    /// Display one frame image (Extend Width info and Height info)
    /// </summary>
    /// <param name="pcDisplayInfoEx">Image information</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int DisplayOneFrameEx(ref CDisplayFrameInfoEx pcDisplayInfoEx)
    {
      if (pcDisplayInfoEx == null || IntPtr.Zero == pcDisplayInfoEx.WindowHandle)
        return -2147483644;
      return CCamCtrlRef.MV_CC_DisplayOneFrameEx(this.handle, pcDisplayInfoEx.WindowHandle, ref new MV_DISPLAY_FRAME_INFO_EX()
      {
        enPixelType = pcDisplayInfoEx.ImageEx.PixelType,
        nDataLen = pcDisplayInfoEx.ImageEx.FrameLen,
        nHeight = pcDisplayInfoEx.ImageEx.nExtendHeight,
        nWidth = pcDisplayInfoEx.ImageEx.nExtendWidth,
        pData = pcDisplayInfoEx.ImageAddr
      });
    }

    /// <summary>
    /// Set the number of the internal image cache nodes in SDK(Greater than or equal to 1, to be called before the capture)
    /// </summary>
    /// <param name="nNum">Number of cache nodes</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetImageNodeNum(uint nNum) => CCamCtrlRef.MV_CC_SetImageNodeNum(this.handle, nNum);

    /// <summary>Set Grab Strategy</summary>
    /// <param name="enGrabStrategy">The value of grab strategy</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetGrabStrategy(MV_GRAB_STRATEGY enGrabStrategy) => CCamCtrlRef.MV_CC_SetGrabStrategy(this.handle, enGrabStrategy);

    /// <summary>
    /// Set The Size of Output Queue(Only work under the strategy of MV_GrabStrategy_LatestImages，rang：1-ImageNodeNum)
    /// </summary>
    /// <param name="nOutputQueueSize">The Size of Output Queue</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetOutputQueueSize(uint nOutputQueueSize) => CCamCtrlRef.MV_CC_SetOutputQueueSize(this.handle, nOutputQueueSize);

    /// <summary>Force IP</summary>
    /// <param name="nIP">IP to set</param>
    /// <param name="nSubNetMask">Subnet mask</param>
    /// <param name="nDefaultGateWay">Default gateway</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_ForceIpEx(uint nIP, uint nSubNetMask, uint nDefaultGateWay) => CCamCtrlRef.MV_GIGE_ForceIpEx(this.handle, nIP, nSubNetMask, nDefaultGateWay);

    /// <summary>IP configuration method</summary>
    /// <param name="enType">IP type</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetIpConfig(MV_GIGE_IP_CONFIG_TYPE enType) => CCamCtrlRef.MV_GIGE_SetIpConfig(this.handle, (uint) enType);

    /// <summary>
    /// Set to use only one mode,type: MV_NET_TRANS_x. When do not set, priority is to use driver by default
    /// </summary>
    /// <param name="enType">Net transmission mode, refer to MV_NET_TRANS_x</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetNetTransMode(MV_GIGE_Net_Transfer_Mode enType) => CCamCtrlRef.MV_GIGE_SetNetTransMode(this.handle, (uint) enType);

    /// <summary>Get net transmission information</summary>
    /// <param name="pcNetTransInfo">Transmission information</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_GetNetTransInfo(ref CNetTransInfo pcNetTransInfo)
    {
      if (pcNetTransInfo == null)
        return -2147483644;
      MV_NETTRANS_INFO pstInfo = new MV_NETTRANS_INFO();
      int netTransInfo = CCamCtrlRef.MV_GIGE_GetNetTransInfo(this.handle, ref pstInfo);
      if (netTransInfo != 0)
        return netTransInfo;
      pcNetTransInfo.NetRecvFrameCount = pstInfo.nNetRecvFrameCount;
      pcNetTransInfo.RequestResendPacketCount = pstInfo.nRequestResendPacketCount;
      pcNetTransInfo.ResendPacketCount = pstInfo.nResendPacketCount;
      pcNetTransInfo.ReviceDataSize = pstInfo.nReviceDataSize;
      pcNetTransInfo.ThrowFrameCount = pstInfo.nThrowFrameCount;
      return 0;
    }

    /// <summary>Set GVSP streaming timeout</summary>
    /// <param name="nMillisec">Timeout, default 300ms, range: &gt;10ms</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetGvspTimeout(uint nMillisec) => CCamCtrlRef.MV_GIGE_SetGvspTimeout(this.handle, nMillisec);

    /// <summary>Get GVSP streaming timeout</summary>
    /// <param name="pMillisec">Timeout, ms as unit</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_GetGvspTimeout(ref uint pMillisec) => CCamCtrlRef.MV_GIGE_GetGvspTimeout(this.handle, ref pMillisec);

    /// <summary>Set GVCP cammand timeout</summary>
    /// <param name="nMillisec">Timeout, ms as unit, range: 0-10000</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetGvcpTimeout(uint nMillisec) => CCamCtrlRef.MV_GIGE_SetGvcpTimeout(this.handle, nMillisec);

    /// <summary>Get GVCP cammand timeout</summary>
    /// <param name="pMillisec">Timeout, ms as unit</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_GetGvcpTimeout(ref uint pMillisec) => CCamCtrlRef.MV_GIGE_GetGvcpTimeout(this.handle, ref pMillisec);

    /// <summary>Set the number of retry GVCP cammand</summary>
    /// <param name="nRetryGvcpTimes">The number of retries，rang：0-100</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetRetryGvcpTimes(uint nRetryGvcpTimes) => CCamCtrlRef.MV_GIGE_SetRetryGvcpTimes(this.handle, nRetryGvcpTimes);

    /// <summary>Get the number of retry GVCP cammand</summary>
    /// <param name="pnRetryGvcpTimes">The number of retries</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_GetRetryGvcpTimes(ref uint pnRetryGvcpTimes) => CCamCtrlRef.MV_GIGE_GetRetryGvcpTimes(this.handle, ref pnRetryGvcpTimes);

    /// <summary>Get the optimal Packet Size, Only support GigE Camera</summary>
    /// <returns>Optimal packet size</returns>
    public int GIGE_GetOptimalPacketSize() => CCamCtrlRef.MV_CC_GetOptimalPacketSize(this.handle);

    /// <summary>Set whethe to enable resend, and set resend</summary>
    /// <param name="bEnable">Enable resend</param>
    /// <param name="nMaxResendPercent">Max resend persent</param>
    /// <param name="nResendTimeout">Resend timeout</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetResend(uint bEnable, uint nMaxResendPercent, uint nResendTimeout) => CCamCtrlRef.MV_GIGE_SetResend(this.handle, bEnable, nMaxResendPercent, nResendTimeout);

    /// <summary>Set the max resend retry times</summary>
    /// <param name="nRetryTimes">The max times to retry resending lost packets，default 20</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetResendMaxRetryTimes(uint nRetryTimes) => CCamCtrlRef.MV_GIGE_SetResendMaxRetryTimes(this.handle, nRetryTimes);

    /// <summary>Get the max resend retry times</summary>
    /// <param name="pnRetryTimes">the max times to retry resending lost packets</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_GetResendMaxRetryTimes(ref uint pnRetryTimes) => CCamCtrlRef.MV_GIGE_GetResendMaxRetryTimes(this.handle, ref pnRetryTimes);

    /// <summary>Set time interval between same resend requests</summary>
    /// <param name="nMillisec">The time interval between same resend requests,default 10ms</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetResendTimeInterval(uint nMillisec) => CCamCtrlRef.MV_GIGE_SetResendTimeInterval(this.handle, nMillisec);

    /// <summary>Get time interval between same resend requests</summary>
    /// <param name="pnMillisec">The time interval between same resend requests</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_GetResendTimeInterval(ref uint pnMillisec) => CCamCtrlRef.MV_GIGE_GetResendTimeInterval(this.handle, ref pnMillisec);

    /// <summary>Set transmission type,Unicast or Multicast</summary>
    /// <param name="pcTransmissionType">Struct of transmission type</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_SetTransmissionType(ref CTransMissionType pcTransmissionType)
    {
      if (pcTransmissionType == null)
        return -2147483644;
      MV_CC_TRANSMISSION_TYPE pstTransmissionType = new MV_CC_TRANSMISSION_TYPE();
      int num = CCamCtrlRef.MV_GIGE_SetTransmissionType(this.handle, ref pstTransmissionType);
      if (num != 0)
        return num;
      pcTransmissionType.TransmissionType = pstTransmissionType.enTransmissionType;
      pcTransmissionType.DestIp = pstTransmissionType.nDestIp;
      pcTransmissionType.DestPort = pstTransmissionType.nDestPort;
      return 0;
    }

    /// <summary>Issue Action Command</summary>
    /// <param name="pcActionCmdInfo">Action Command info</param>
    /// <param name="pcActionCmdResults">Action Command Result List</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GIGE_IssueActionCommand(
      ref CActionCmdInfo pcActionCmdInfo,
      ref CActionCmdResultList pcActionCmdResults)
    {
      if (pcActionCmdInfo == null || pcActionCmdResults == null)
        return -2147483644;
      MV_ACTION_CMD_INFO pstActionCmdInfo = new MV_ACTION_CMD_INFO();
      pstActionCmdInfo.bActionTimeEnable = pcActionCmdInfo.ActionTimeEnable;
      pstActionCmdInfo.nActionTime = pcActionCmdInfo.ActionTime;
      pstActionCmdInfo.nDeviceKey = pcActionCmdInfo.DeviceKey;
      pstActionCmdInfo.nGroupKey = pcActionCmdInfo.GroupKey;
      pstActionCmdInfo.nGroupMask = pcActionCmdInfo.GroupMask;
      pstActionCmdInfo.nTimeOut = pcActionCmdInfo.TimeOut;
      pstActionCmdInfo.pBroadcastAddress = pcActionCmdInfo.BroadcastAddress;
      MV_ACTION_CMD_RESULT_LIST pstActionCmdResults = new MV_ACTION_CMD_RESULT_LIST();
      int num = CCamCtrlRef.MV_GIGE_IssueActionCommand(ref pstActionCmdInfo, ref pstActionCmdResults);
      if (num != 0)
        return num;
      pcActionCmdResults.NumResults = pstActionCmdResults.nNumResults;
      pcActionCmdResults.Results = pstActionCmdResults.pResults;
      return 0;
    }

    /// <summary>Get Multicast Status</summary>
    /// <param name="pcDevInfo">Device Information</param>
    /// <param name="pbStatus">Status of Multicast</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GIGE_GetMulticastStatus(ref CCameraInfo pcDevInfo, ref bool pbStatus)
    {
      if (pcDevInfo == null)
        return -2147483644;
      MV_CC_DEVICE_INFO pstDevInfo = new MV_CC_DEVICE_INFO(0U);
      if (1U == pcDevInfo.nTLayerType)
      {
        CGigECameraInfo cgigEcameraInfo = (CGigECameraInfo) pcDevInfo;
        pstDevInfo.nMajorVer = cgigEcameraInfo.nMajorVer;
        pstDevInfo.nMinorVer = cgigEcameraInfo.nMinorVer;
        pstDevInfo.nMacAddrHigh = cgigEcameraInfo.nMacAddrHigh;
        pstDevInfo.nMacAddrLow = cgigEcameraInfo.nMacAddrLow;
        pstDevInfo.nTLayerType = cgigEcameraInfo.nTLayerType;
        CInnerTool.StructToBytes<MV_GIGE_DEVICE_INFO>(new MV_GIGE_DEVICE_INFO()
        {
          chDeviceVersion = cgigEcameraInfo.chDeviceVersion,
          chManufacturerName = cgigEcameraInfo.chManufacturerName,
          chManufacturerSpecificInfo = cgigEcameraInfo.chManufacturerSpecificInfo,
          chModelName = cgigEcameraInfo.chModelName,
          chSerialNumber = cgigEcameraInfo.chSerialNumber,
          chUserDefinedName = cgigEcameraInfo.chUserDefinedName,
          nCurrentIp = cgigEcameraInfo.nCurrentIp,
          nCurrentSubNetMask = cgigEcameraInfo.nCurrentSubNetMask,
          nDefultGateWay = cgigEcameraInfo.nDefultGateWay,
          nIpCfgCurrent = cgigEcameraInfo.nIpCfgCurrent,
          nIpCfgOption = cgigEcameraInfo.nIpCfgOption,
          nNetExport = cgigEcameraInfo.nNetExport
        }, pstDevInfo.SpecialInfo.stGigEInfo);
      }
      else if (4U == pcDevInfo.nTLayerType)
      {
        CUSBCameraInfo cusbCameraInfo = (CUSBCameraInfo) pcDevInfo;
        pstDevInfo.nMajorVer = cusbCameraInfo.nMajorVer;
        pstDevInfo.nMinorVer = cusbCameraInfo.nMinorVer;
        pstDevInfo.nMacAddrHigh = cusbCameraInfo.nMacAddrHigh;
        pstDevInfo.nMacAddrLow = cusbCameraInfo.nMacAddrLow;
        pstDevInfo.nTLayerType = cusbCameraInfo.nTLayerType;
        CInnerTool.StructToBytes<MV_USB3_DEVICE_INFO>(new MV_USB3_DEVICE_INFO()
        {
          chDeviceGUID = cusbCameraInfo.chDeviceGUID,
          chDeviceVersion = cusbCameraInfo.chDeviceVersion,
          chFamilyName = cusbCameraInfo.chFamilyName,
          chManufacturerName = cusbCameraInfo.chManufacturerName,
          chModelName = cusbCameraInfo.chModelName,
          chSerialNumber = cusbCameraInfo.chSerialNumber,
          chUserDefinedName = cusbCameraInfo.chUserDefinedName,
          chVendorName = cusbCameraInfo.chVendorName,
          CrtlInEndPoint = cusbCameraInfo.CrtlInEndPoint,
          CrtlOutEndPoint = cusbCameraInfo.CrtlOutEndPoint,
          EventEndPoint = cusbCameraInfo.EventEndPoint,
          idProduct = cusbCameraInfo.idProduct,
          idVendor = cusbCameraInfo.idVendor,
          nbcdUSB = cusbCameraInfo.nbcdUSB,
          nDeviceNumber = cusbCameraInfo.nDeviceNumber,
          StreamEndPoint = cusbCameraInfo.StreamEndPoint
        }, pstDevInfo.SpecialInfo.stUsb3VInfo);
      }
      else
      {
        if (8U != pcDevInfo.nTLayerType)
          return -2147483647;
        CCamLCameraInfo ccamLcameraInfo = (CCamLCameraInfo) pcDevInfo;
        pstDevInfo.nMajorVer = ccamLcameraInfo.nMajorVer;
        pstDevInfo.nMinorVer = ccamLcameraInfo.nMinorVer;
        pstDevInfo.nMacAddrHigh = ccamLcameraInfo.nMacAddrHigh;
        pstDevInfo.nMacAddrLow = ccamLcameraInfo.nMacAddrLow;
        pstDevInfo.nTLayerType = ccamLcameraInfo.nTLayerType;
        CInnerTool.StructToBytes<MV_CamL_DEV_INFO>(new MV_CamL_DEV_INFO()
        {
          chDeviceVersion = ccamLcameraInfo.chDeviceVersion,
          chFamilyName = ccamLcameraInfo.chFamilyName,
          chManufacturerName = ccamLcameraInfo.chManufacturerName,
          chModelName = ccamLcameraInfo.chModelName,
          chPortID = ccamLcameraInfo.chPortID,
          chSerialNumber = ccamLcameraInfo.chSerialNumber
        }, pstDevInfo.SpecialInfo.stCamLInfo);
      }
      return CCamCtrlRef.MV_GIGE_GetMulticastStatus(ref pstDevInfo, ref pbStatus);
    }

    /// <summary>Set transfer size of U3V device</summary>
    /// <param name="nTransferSize">Transfer size，Byte，default：1M，rang：&gt;=0x10000</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int USB_SetTransferSize(uint nTransferSize) => CCamCtrlRef.MV_USB_SetTransferSize(this.handle, nTransferSize);

    /// <summary>Get transfer size of U3V device</summary>
    /// <param name="pnTransferSize">Transfer size，Byte</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int USB_GetTransferSize(ref uint pnTransferSize) => CCamCtrlRef.MV_USB_GetTransferSize(this.handle, ref pnTransferSize);

    /// <summary>Set transfer ways of U3V device</summary>
    /// <param name="nTransferWays">Transfer ways，rang：1-10</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int USB_SetTransferWays(uint nTransferWays) => CCamCtrlRef.MV_USB_SetTransferWays(this.handle, nTransferWays);

    /// <summary>Get transfer ways of U3V device</summary>
    /// <param name="pnTransferWays">Transfer ways</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int USB_GetTransferWays(ref uint pnTransferWays) => CCamCtrlRef.MV_USB_GetTransferWays(this.handle, ref pnTransferWays);

    /// <summary>注册流异常消息回调，在打开设备之后调用（只支持U3V相机）</summary>
    /// <param name="cbException">Exception CallBack Function</param>
    /// <param name="pUser">User defined variable</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int USB_RegisterStreamExceptionCallBack(
      cbStreamExceptiondelegate cbException,
      IntPtr pUser)
    {
      return CCamCtrlRef.MV_USB_RegisterStreamExceptionCallBack(this.handle, cbException, pUser);
    }

    /// <summary>Set the number of U3V device event cache nodes</summary>
    /// <param name="nEventNodeNum">Event Node Number</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int USB_SetEventNodeNum(uint nEventNodeNum) => CCamCtrlRef.MV_USB_SetEventNodeNum(this.handle, nEventNodeNum);

    /// <summary>
    /// Set U3V Synchronisation timeout,range is 0 ~ UINT_MAX(minimum value contains 0,maximum value according to the operating system)
    /// </summary>
    /// <param name="nMills">time out(ms),default 1000ms</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int USB_SetSyncTimeOut(uint nMills) => CCamCtrlRef.MV_USB_SetSyncTimeOut(this.handle, nMills);

    /// <summary>Get U3V Camera Synchronisation timeout</summary>
    /// <param name="pnMills">Get Synchronisation time(ms)</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int USB_GetSyncTimeOut(ref uint pnMills) => CCamCtrlRef.MV_USB_GetSyncTimeOut(this.handle, ref pnMills);

    /// <summary>设置设备波特率</summary>
    /// <param name="enBaudrate">设置的波特率值，如MV_CAML_BAUDRATE_9600</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    public int CAML_SetDeviceBaudrate(MV_CAML_BAUDRATE enBaudrate) => CCamCtrlRef.MV_CAML_SetDeviceBaudrate(this.handle, (uint) enBaudrate);

    /// <summary>获取设备波特率</summary>
    /// <param name="penCurrentBaudrate">波特率信息，如MV_CAML_BAUDRATE_9600</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    public int CAML_GetDeviceBaudrate(ref MV_CAML_BAUDRATE penCurrentBaudrate)
    {
      uint pnCurrentBaudrate = 0;
      int deviceBaudrate = CCamCtrlRef.MV_CAML_GetDeviceBaudrate(this.handle, ref pnCurrentBaudrate);
      if (deviceBaudrate != 0)
      {
        penCurrentBaudrate = MV_CAML_BAUDRATE.MV_CAML_BAUDRATE_UNKNOW;
        return deviceBaudrate;
      }
      penCurrentBaudrate = (MV_CAML_BAUDRATE) pnCurrentBaudrate;
      return deviceBaudrate;
    }

    /// <summary>获取设备与主机间连接支持的波特率</summary>
    /// <param name="penBaudrateAblity">支持的波特率信息，所支持波特率的或运算结果，如MV_CAML_BAUDRATE_9600</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    public int CAML_GetSupportBaudrates(ref MV_CAML_BAUDRATE penBaudrateAblity)
    {
      uint pnBaudrateAblity = 0;
      int supportBaudrates = CCamCtrlRef.MV_CAML_GetSupportBaudrates(this.handle, ref pnBaudrateAblity);
      if (supportBaudrates != 0)
      {
        penBaudrateAblity = MV_CAML_BAUDRATE.MV_CAML_BAUDRATE_UNKNOW;
        return supportBaudrates;
      }
      penBaudrateAblity = (MV_CAML_BAUDRATE) pnBaudrateAblity;
      return supportBaudrates;
    }

    /// <summary>Sets the timeout for operations on the serial port</summary>
    /// <param name="nMillisec">Timeout in [ms] for operations on the serial port.</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int CAML_SetGenCPTimeOut(uint nMillisec) => CCamCtrlRef.MV_CAML_SetGenCPTimeOut(this.handle, nMillisec);

    /// <summary>卸载cti库</summary>
    /// <param name="strGenTLPath">枚举卡时加载的cti文件路径</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    public int UnloadGenTLLibrary(string strGenTLPath) => CCamCtrlRef.MV_CC_UnloadGenTLLibrary(strGenTLPath);

    /// <summary>Create Device Handle Based On GenTL Device Info</summary>
    /// <param name="pcDevInfo">Device Information Structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int CreateHandleByGenTL(ref CGenTLDevInfo pcDevInfo)
    {
      if (pcDevInfo == null)
        return -2147483644;
      if (IntPtr.Zero != this.handle)
      {
        this.DestroyHandle();
        this.handle = IntPtr.Zero;
      }
      return CCamCtrlRef.MV_CC_CreateHandleByGenTL(ref this.handle, ref new MV_GENTL_DEV_INFO()
      {
        chDeviceID = pcDevInfo.chDeviceID,
        chDeviceVersion = pcDevInfo.chDeviceVersion,
        chDisplayName = pcDevInfo.chDisplayName,
        chInterfaceID = pcDevInfo.chInterfaceID,
        chModelName = pcDevInfo.chModelName,
        chSerialNumber = pcDevInfo.chSerialNumber,
        chTLType = pcDevInfo.chTLType,
        chUserDefinedName = pcDevInfo.chUserDefinedName,
        chVendorName = pcDevInfo.chVendorName,
        nCtiIndex = pcDevInfo.nCtiIndex
      });
    }

    /// <summary>Device Local Upgrade</summary>
    /// <param name="pFilePathName">File path and name</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int LocalUpgrade(string pFilePathName) => CCamCtrlRef.MV_CC_LocalUpgrade(this.handle, pFilePathName);

    /// <summary>Get Upgrade Progress</summary>
    /// <param name="pnProcess">Value of Progress</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int GetUpgradeProcess(ref uint pnProcess) => CCamCtrlRef.MV_CC_GetUpgradeProcess(this.handle, ref pnProcess);

    /// <summary>Read Memory</summary>
    /// <param name="pBuffer">Used as a return value, save the read-in memory value(Memory value is stored in accordance with the big end model)</param>
    /// <param name="nAddress">Memory address to be read, which can be obtained from the Camera.xml file of the device, the form xml node value of xxx_RegAddr</param>
    /// <param name="nLength">Length of the memory to be read</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int ReadMemory(IntPtr pBuffer, long nAddress, long nLength) => CCamCtrlRef.MV_CC_ReadMemory(this.handle, pBuffer, nAddress, nLength);

    /// <summary>Write Memory</summary>
    /// <param name="pBuffer">Memory value to be written ( Note the memory value to be stored in accordance with the big end model)</param>
    /// <param name="nAddress">Memory address to be written, which can be obtained from the Camera.xml file of the device, the form xml node value of xxx_RegAddr</param>
    /// <param name="nLength">Length of the memory to be written</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int WriteMemory(IntPtr pBuffer, long nAddress, long nLength) => CCamCtrlRef.MV_CC_WriteMemory(this.handle, pBuffer, nAddress, nLength);

    /// <summary>
    /// Register Exception Message CallBack, call after open device
    /// </summary>
    /// <param name="cbException">Exception Message CallBack Function</param>
    /// <param name="pUser">User defined variable</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int RegisterExceptionCallBack(cbExceptiondelegate cbException, IntPtr pUser) => CCamCtrlRef.MV_CC_RegisterExceptionCallBack(this.handle, cbException, pUser);

    /// <summary>
    /// Register event callback, which is called after the device is opened
    /// </summary>
    /// <param name="cbEvent">Event CallBack Function</param>
    /// <param name="pUser">User defined variable</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int RegisterAllEventCallBack(cbEventdelegateEx cbEvent, IntPtr pUser) => CCamCtrlRef.MV_CC_RegisterAllEventCallBack(this.handle, cbEvent, pUser);

    /// <summary>
    /// Register single event callback, which is called after the device is opened
    /// </summary>
    /// <param name="pEventName">Event name</param>
    /// <param name="cbEvent">Event CallBack Function</param>
    /// <param name="pUser">User defined variable</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int RegisterEventCallBackEx(string pEventName, cbEventdelegateEx cbEvent, IntPtr pUser) => CCamCtrlRef.MV_CC_RegisterEventCallBackEx(this.handle, pEventName, cbEvent, pUser);

    /// <summary>
    /// Open the GUI interface for getting or setting camera parameters
    /// </summary>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int OpenParamsGUI() => CCamCtrlRef.MV_CC_OpenParamsGUI(this.handle);

    /// <summary>
    /// Save image, support Bmp and Jpeg. Encoding quality(50-99]
    /// </summary>
    /// <param name="pcSaveParam">Save the image parameters object</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int SaveImageEx(ref CSaveImageParam pcSaveParam)
    {
      if (pcSaveParam == null || IntPtr.Zero == pcSaveParam.InImage.ImageAddr)
        return -2147483644;
      MV_SAVE_IMAGE_PARAM_EX stSaveParam1 = new MV_SAVE_IMAGE_PARAM_EX();
      MV_SAVE_IMAGE_PARAM_EX2 stSaveParam2 = new MV_SAVE_IMAGE_PARAM_EX2();
      if (pcSaveParam.InImage.Width >= ushort.MaxValue || pcSaveParam.InImage.Height >= ushort.MaxValue)
      {
        uint pixelSize = CInnerTool.GetPixelSize(pcSaveParam.InImage);
        if (pcSaveParam.OutImage != null)
        {
          int num = pcSaveParam.OutImage.AllocateUnmanagedMemory(pixelSize);
          if (num != 0)
            return num;
        }
        stSaveParam2.pData = pcSaveParam.InImage.ImageAddr;
        stSaveParam2.nDataLen = pcSaveParam.InImage.FrameLen;
        stSaveParam2.enPixelType = pcSaveParam.InImage.PixelType;
        stSaveParam2.nWidth = pcSaveParam.InImage.ExtendWidth;
        stSaveParam2.nHeight = pcSaveParam.InImage.ExtendHeight;
        stSaveParam2.pImageBuffer = pcSaveParam.OutImage.ImageAddr;
        stSaveParam2.nBufferSize = pcSaveParam.OutImage.ImageSize;
        stSaveParam2.enImageType = pcSaveParam.ImageType;
        stSaveParam2.nJpgQuality = pcSaveParam.JpgQuality;
        stSaveParam2.iMethodValue = pcSaveParam.MethodValue;
        int num1 = CCamCtrlRef.MV_CC_SaveImageEx3(this.handle, ref stSaveParam2);
        if (num1 != 0)
          return num1;
        pcSaveParam.OutImage.UpdateImageInfo(stSaveParam2.pImageBuffer, stSaveParam2.nImageLen);
        return 0;
      }
      uint pixelSize1 = CInnerTool.GetPixelSize(pcSaveParam.InImage);
      if (pcSaveParam.OutImage != null)
      {
        int num = pcSaveParam.OutImage.AllocateUnmanagedMemory(pixelSize1);
        if (num != 0)
          return num;
      }
      stSaveParam1.pData = pcSaveParam.InImage.ImageAddr;
      stSaveParam1.nDataLen = pcSaveParam.InImage.FrameLen;
      stSaveParam1.enPixelType = pcSaveParam.InImage.PixelType;
      stSaveParam1.nWidth = pcSaveParam.InImage.Width;
      stSaveParam1.nHeight = pcSaveParam.InImage.Height;
      stSaveParam1.pImageBuffer = pcSaveParam.OutImage.ImageAddr;
      stSaveParam1.nBufferSize = pcSaveParam.OutImage.ImageSize;
      stSaveParam1.enImageType = pcSaveParam.ImageType;
      stSaveParam1.nJpgQuality = pcSaveParam.JpgQuality;
      stSaveParam1.iMethodValue = pcSaveParam.MethodValue;
      int num2 = CCamCtrlRef.MV_CC_SaveImageEx2(this.handle, ref stSaveParam1);
      if (num2 != 0)
        return num2;
      pcSaveParam.OutImage.UpdateImageInfo(stSaveParam1.pImageBuffer, stSaveParam1.nImageLen);
      return 0;
    }

    /// <summary>
    /// Save the image file, support Bmp、 Jpeg、Png and Tiff. Encoding quality(50-99]
    /// </summary>
    /// <param name="pcSaveFileParam">Save the image parameters object</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int SaveImageToFile(ref CSaveImgToFileParam pcSaveFileParam)
    {
      if (pcSaveFileParam == null)
        return -2147483644;
      MV_SAVE_IMG_TO_FILE_PARAM pstSaveFileParam = new MV_SAVE_IMG_TO_FILE_PARAM();
      MV_SAVE_IMG_TO_FILE_PARAM_EX pstSaveFileParamEx = new MV_SAVE_IMG_TO_FILE_PARAM_EX();
      if (pcSaveFileParam.Image.Width >= ushort.MaxValue || pcSaveFileParam.Image.Height >= ushort.MaxValue)
      {
        pstSaveFileParamEx.nWidth = pcSaveFileParam.Image.ExtendWidth;
        pstSaveFileParamEx.nHeight = pcSaveFileParam.Image.ExtendHeight;
        pstSaveFileParamEx.enPixelType = pcSaveFileParam.Image.PixelType;
        pstSaveFileParamEx.pData = pcSaveFileParam.Image.ImageAddr;
        pstSaveFileParamEx.nDataLen = pcSaveFileParam.Image.FrameLen;
        pstSaveFileParamEx.enImageType = pcSaveFileParam.ImageType;
        pstSaveFileParamEx.pImagePath = pcSaveFileParam.ImagePath;
        pstSaveFileParamEx.nQuality = pcSaveFileParam.Quality;
        pstSaveFileParamEx.iMethodValue = pcSaveFileParam.MethodValue;
        return CCamCtrlRef.MV_CC_SaveImageToFileEx(this.handle, ref pstSaveFileParamEx);
      }
      pstSaveFileParam.enImageType = pcSaveFileParam.ImageType;
      pstSaveFileParam.enPixelType = pcSaveFileParam.Image.PixelType;
      pstSaveFileParam.nWidth = pcSaveFileParam.Image.Width;
      pstSaveFileParam.nHeight = pcSaveFileParam.Image.Height;
      pstSaveFileParam.nDataLen = pcSaveFileParam.Image.FrameLen;
      pstSaveFileParam.pData = pcSaveFileParam.Image.ImageAddr;
      pstSaveFileParam.pImagePath = pcSaveFileParam.ImagePath;
      pstSaveFileParam.nQuality = pcSaveFileParam.Quality;
      pstSaveFileParam.iMethodValue = pcSaveFileParam.MethodValue;
      return CCamCtrlRef.MV_CC_SaveImageToFile(this.handle, ref pstSaveFileParam);
    }

    /// <summary>Save 3D point data, support PLY、CSV and OBJ</summary>
    /// <param name="pcPointDataParam">Save 3D point data parameters structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SavePointCloudData(ref CSavePointCloudParam pcPointDataParam)
    {
      if (pcPointDataParam == null || IntPtr.Zero == pcPointDataParam.InImage.ImageAddr)
        return -2147483644;
      MV_SAVE_POINT_CLOUD_PARAM pstPointDataParam = new MV_SAVE_POINT_CLOUD_PARAM();
      uint nPreBufSize = pcPointDataParam.InImage.Width >= ushort.MaxValue || pcPointDataParam.InImage.Height >= ushort.MaxValue ? CInnerTool.GetPixelSize(pcPointDataParam.InImage) : CInnerTool.GetPixelSize(pcPointDataParam.InImage);
      if (pcPointDataParam.OutImage != null)
      {
        int num = pcPointDataParam.OutImage.AllocateUnmanagedMemory(nPreBufSize);
        if (num != 0)
          return num;
      }
      pstPointDataParam.nLinePntNum = pcPointDataParam.LinePntNum;
      pstPointDataParam.nLineNum = pcPointDataParam.LineNum;
      pstPointDataParam.enSrcPixelType = pcPointDataParam.InImage.PixelType;
      pstPointDataParam.pSrcData = pcPointDataParam.InImage.ImageAddr;
      pstPointDataParam.nSrcDataLen = pcPointDataParam.InImage.FrameLen;
      pstPointDataParam.pDstBuf = pcPointDataParam.OutImage.ImageAddr;
      pstPointDataParam.nDstBufSize = pcPointDataParam.OutImage.ImageSize;
      pstPointDataParam.enPointCloudFileType = pcPointDataParam.PointCloudFileType;
      int num1 = CCamCtrlRef.MV_CC_SavePointCloudData(this.handle, ref pstPointDataParam);
      if (num1 != 0)
        return num1;
      pcPointDataParam.OutImage.UpdateImageInfo(pstPointDataParam.pDstBuf, pstPointDataParam.nDstBufLen);
      return 0;
    }

    /// <summary>Rotate Image</summary>
    /// <param name="pcRotateParam">Rotate image parameter structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int RotateImage(ref CRotateImageParam pcRotateParam)
    {
      if (pcRotateParam == null || IntPtr.Zero == pcRotateParam.InImage.ImageAddr)
        return -2147483644;
      MV_CC_ROTATE_IMAGE_PARAM pstRotateParam = new MV_CC_ROTATE_IMAGE_PARAM();
      uint pixelSize;
      if (pcRotateParam.InImage.Width >= ushort.MaxValue || pcRotateParam.InImage.Height >= ushort.MaxValue)
      {
        pixelSize = CInnerTool.GetPixelSize(pcRotateParam.InImage);
        pstRotateParam.nWidth = pcRotateParam.InImage.ExtendWidth;
        pstRotateParam.nHeight = pcRotateParam.InImage.ExtendHeight;
      }
      else
      {
        pixelSize = CInnerTool.GetPixelSize(pcRotateParam.InImage);
        pstRotateParam.nWidth = (uint) pcRotateParam.InImage.Width;
        pstRotateParam.nHeight = (uint) pcRotateParam.InImage.Height;
      }
      if (pcRotateParam.OutImage != null)
      {
        int num = pcRotateParam.OutImage.AllocateUnmanagedMemory(pixelSize);
        if (num != 0)
          return num;
      }
      pstRotateParam.enPixelType = pcRotateParam.InImage.PixelType;
      pstRotateParam.pSrcData = pcRotateParam.InImage.ImageAddr;
      pstRotateParam.nSrcDataLen = pcRotateParam.InImage.FrameLen;
      pstRotateParam.pDstBuf = pcRotateParam.OutImage.ImageAddr;
      pstRotateParam.nDstBufSize = pcRotateParam.OutImage.ImageSize;
      pstRotateParam.enRotationAngle = pcRotateParam.RotationAngle;
      int num1 = CCamCtrlRef.MV_CC_RotateImage(this.handle, ref pstRotateParam);
      if (num1 != 0)
        return num1;
      pcRotateParam.OutImage.UpdateImageInfo(pstRotateParam.pDstBuf, pstRotateParam.nDstBufLen, (ushort) pstRotateParam.nHeight, (ushort) pstRotateParam.nWidth, pstRotateParam.enPixelType, pstRotateParam.nHeight, pstRotateParam.nWidth);
      return 0;
    }

    /// <summary>Flip Image</summary>
    /// <param name="pcFlipParam">Flip image parameter structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int FlipImage(ref CFlipImageParam pcFlipParam)
    {
      if (pcFlipParam == null || IntPtr.Zero == pcFlipParam.InImage.ImageAddr)
        return -2147483644;
      MV_CC_FLIP_IMAGE_PARAM pstFlipParam = new MV_CC_FLIP_IMAGE_PARAM();
      uint pixelSize;
      if (pcFlipParam.InImage.Width >= ushort.MaxValue || pcFlipParam.InImage.Height >= ushort.MaxValue)
      {
        pixelSize = CInnerTool.GetPixelSize(pcFlipParam.InImage);
        pstFlipParam.nWidth = pcFlipParam.InImage.ExtendWidth;
        pstFlipParam.nHeight = pcFlipParam.InImage.ExtendHeight;
      }
      else
      {
        pixelSize = CInnerTool.GetPixelSize(pcFlipParam.InImage);
        pstFlipParam.nWidth = (uint) pcFlipParam.InImage.Width;
        pstFlipParam.nHeight = (uint) pcFlipParam.InImage.Height;
      }
      if (pcFlipParam.OutImage != null)
      {
        int num = pcFlipParam.OutImage.AllocateUnmanagedMemory(pixelSize);
        if (num != 0)
          return num;
      }
      pstFlipParam.enPixelType = pcFlipParam.InImage.PixelType;
      pstFlipParam.pSrcData = pcFlipParam.InImage.ImageAddr;
      pstFlipParam.nSrcDataLen = pcFlipParam.InImage.FrameLen;
      pstFlipParam.pDstBuf = pcFlipParam.OutImage.ImageAddr;
      pstFlipParam.nDstBufSize = pcFlipParam.OutImage.ImageSize;
      pstFlipParam.enFlipType = pcFlipParam.FlipType;
      int num1 = CCamCtrlRef.MV_CC_FlipImage(this.handle, ref pstFlipParam);
      if (num1 != 0)
        return num1;
      pcFlipParam.OutImage.UpdateImageInfo(pstFlipParam.pDstBuf, pstFlipParam.nDstBufLen, (ushort) pstFlipParam.nHeight, (ushort) pstFlipParam.nWidth, pstFlipParam.enPixelType, pstFlipParam.nHeight, pstFlipParam.nWidth);
      return 0;
    }

    /// <summary>Pixel format conversion</summary>
    /// <param name="pcCvtParam">Convert Pixel Type parameter structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int ConvertPixelType(ref CPixelConvertParam pcCvtParam)
    {
      if (pcCvtParam == null || IntPtr.Zero == pcCvtParam.InImage.ImageAddr)
        return -2147483644;
      MV_PIXEL_CONVERT_PARAM pstCvtParam = new MV_PIXEL_CONVERT_PARAM();
      MV_PIXEL_CONVERT_PARAM_EX pstCvtParamEx = new MV_PIXEL_CONVERT_PARAM_EX();
      if (pcCvtParam.InImage.Width >= ushort.MaxValue || pcCvtParam.InImage.Height >= ushort.MaxValue)
      {
        uint pixelSize = CInnerTool.GetPixelSize(pcCvtParam.OutImage.PixelType, pcCvtParam.InImage.ExtendWidth, pcCvtParam.InImage.ExtendHeight);
        if (pcCvtParam.OutImage != null)
        {
          int num = pcCvtParam.OutImage.AllocateUnmanagedMemory(pixelSize);
          if (num != 0)
            return num;
        }
        pstCvtParamEx.nWidth = pcCvtParam.InImage.ExtendWidth;
        pstCvtParamEx.nHeight = pcCvtParam.InImage.ExtendHeight;
        pstCvtParamEx.enSrcPixelType = pcCvtParam.InImage.PixelType;
        pstCvtParamEx.pSrcData = pcCvtParam.InImage.ImageAddr;
        pstCvtParamEx.nSrcDataLen = pcCvtParam.InImage.FrameLen;
        pstCvtParamEx.enDstPixelType = pcCvtParam.OutImage.PixelType;
        pstCvtParamEx.pDstBuffer = pcCvtParam.OutImage.ImageAddr;
        pstCvtParamEx.nDstBufferSize = pcCvtParam.OutImage.ImageSize;
        int num1 = CCamCtrlRef.MV_CC_ConvertPixelTypeEx(this.handle, ref pstCvtParamEx);
        if (num1 != 0)
          return num1;
        pcCvtParam.OutImage.UpdateImageInfo(pstCvtParamEx.pDstBuffer, pstCvtParamEx.nDstLen, (ushort) pstCvtParamEx.nHeight, (ushort) pstCvtParamEx.nWidth, pstCvtParam.enDstPixelType, pstCvtParamEx.nHeight, pstCvtParamEx.nWidth);
        return 0;
      }
      uint pixelSize1 = CInnerTool.GetPixelSize(pcCvtParam.OutImage.PixelType, (uint) pcCvtParam.InImage.Width, (uint) pcCvtParam.InImage.Height);
      if (pixelSize1 == 0U)
        return -2147483647;
      if (pcCvtParam.OutImage != null)
      {
        int num = pcCvtParam.OutImage.AllocateUnmanagedMemory(pixelSize1);
        if (num != 0)
          return num;
      }
      pstCvtParam.nWidth = pcCvtParam.InImage.Width;
      pstCvtParam.nHeight = pcCvtParam.InImage.Height;
      pstCvtParam.enSrcPixelType = pcCvtParam.InImage.PixelType;
      pstCvtParam.pSrcData = pcCvtParam.InImage.ImageAddr;
      pstCvtParam.nSrcDataLen = pcCvtParam.InImage.FrameLen;
      pstCvtParam.enDstPixelType = pcCvtParam.OutImage.PixelType;
      pstCvtParam.pDstBuffer = pcCvtParam.OutImage.ImageAddr;
      pstCvtParam.nDstBufferSize = pcCvtParam.OutImage.ImageSize;
      int num2 = CCamCtrlRef.MV_CC_ConvertPixelType(this.handle, ref pstCvtParam);
      if (num2 != 0)
        return num2;
      pcCvtParam.OutImage.UpdateImageInfo(pstCvtParam.pDstBuffer, pstCvtParam.nDstLen, pstCvtParam.nHeight, pstCvtParam.nWidth, pstCvtParam.enDstPixelType, (uint) pstCvtParam.nHeight, (uint) pstCvtParam.nWidth);
      return 0;
    }

    /// <summary>Pixel format conversion(Use to GetOneFrameTimeout)</summary>
    /// <param name="byteSrcData">Source Image Data</param>
    /// <param name="pcFrameEx">Frame Data Info</param>
    /// <param name="byteDstData">Destination Image Data Buffer</param>
    /// <param name="nDataSize">Image Data Size</param>
    /// <param name="enDstPixelType">Destination Image Pixel Type</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int ConvertPixelType(
      byte[] byteSrcData,
      ref CFrameoutEx pcFrameEx,
      byte[] byteDstData,
      uint nDataSize,
      MvGvspPixelType enDstPixelType)
    {
      if (pcFrameEx == null || byteSrcData == null || (long) byteDstData.Length != (long) nDataSize)
        return -2147483644;
      IntPtr num1 = Marshal.UnsafeAddrOfPinnedArrayElement((Array) byteSrcData, 0);
      if (IntPtr.Zero == num1)
        return -2147483644;
      IntPtr num2 = Marshal.UnsafeAddrOfPinnedArrayElement((Array) byteDstData, 0);
      if (IntPtr.Zero == num2)
        return -2147483644;
      MV_PIXEL_CONVERT_PARAM pstCvtParam = new MV_PIXEL_CONVERT_PARAM();
      MV_PIXEL_CONVERT_PARAM_EX pstCvtParamEx = new MV_PIXEL_CONVERT_PARAM_EX();
      uint num3 = 0;
      if (pcFrameEx.pcImageInfoEx.Width >= ushort.MaxValue || pcFrameEx.pcImageInfoEx.Height >= ushort.MaxValue)
      {
        num3 = CInnerTool.GetPixelSize(enDstPixelType, pcFrameEx.pcImageInfoEx.nExtendWidth, pcFrameEx.pcImageInfoEx.nExtendHeight);
        pstCvtParamEx.nWidth = pcFrameEx.pcImageInfoEx.nExtendWidth;
        pstCvtParamEx.nHeight = pcFrameEx.pcImageInfoEx.nExtendHeight;
        pstCvtParamEx.enSrcPixelType = pcFrameEx.pcImageInfoEx.PixelType;
        pstCvtParamEx.pSrcData = num1;
        pstCvtParamEx.nSrcDataLen = pcFrameEx.pcImageInfoEx.FrameLen;
        pstCvtParamEx.enDstPixelType = enDstPixelType;
        pstCvtParamEx.pDstBuffer = num2;
        pstCvtParamEx.nDstBufferSize = nDataSize;
        int num4 = CCamCtrlRef.MV_CC_ConvertPixelTypeEx(this.handle, ref pstCvtParamEx);
        return num4 != 0 ? num4 : 0;
      }
      if (CInnerTool.GetPixelSize(enDstPixelType, (uint) pcFrameEx.pcImageInfoEx.Width, (uint) pcFrameEx.pcImageInfoEx.Height) == 0U)
        return -2147483647;
      pstCvtParam.nWidth = pcFrameEx.pcImageInfoEx.Width;
      pstCvtParam.nHeight = pcFrameEx.pcImageInfoEx.Height;
      pstCvtParam.enSrcPixelType = pcFrameEx.pcImageInfoEx.PixelType;
      pstCvtParam.pSrcData = num1;
      pstCvtParam.nSrcDataLen = pcFrameEx.pcImageInfoEx.FrameLen;
      pstCvtParam.enDstPixelType = enDstPixelType;
      pstCvtParam.pDstBuffer = num2;
      pstCvtParam.nDstBufferSize = nDataSize;
      int num5 = CCamCtrlRef.MV_CC_ConvertPixelType(this.handle, ref pstCvtParam);
      return num5 != 0 ? num5 : 0;
    }

    /// <summary>Interpolation algorithm type setting</summary>
    /// <param name="nBayerCvtQuality">Bayer interpolation method  0-Fast 1-Equilibrium 2-Optimal</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int SetBayerCvtQuality(uint nBayerCvtQuality) => CCamCtrlRef.MV_CC_SetBayerCvtQuality(this.handle, nBayerCvtQuality);

    /// <summary>Set Bayer Gamma value</summary>
    /// <param name="fBayerGammaValue">Gamma value[0.1,4.0]</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int SetBayerGammaValue(float fBayerGammaValue) => CCamCtrlRef.MV_CC_SetBayerGammaValue(this.handle, fBayerGammaValue);

    /// <summary>Set Gamma value</summary>
    /// <param name="enSrcPixelType">PixelType,support PixelType_Gvsp_Mono8,Bayer8/10/12/16</param>
    /// <param name="fGammaValue">Gamma value[0.1,4.0]</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetGammaValue(MvGvspPixelType enSrcPixelType, float fGammaValue) => CCamCtrlRef.MV_CC_SetGammaValue(this.handle, enSrcPixelType, fGammaValue);

    /// <summary>Set Gamma param</summary>
    /// <param name="pcGammaParam">Gamma parameter structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetBayerGammaParam(ref CGammaParam pcGammaParam)
    {
      if (pcGammaParam == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_SetBayerGammaParam(this.handle, ref new MV_CC_GAMMA_PARAM()
      {
        enGammaType = pcGammaParam.GammaType,
        fGammaValue = pcGammaParam.GammaValue,
        nGammaCurveBufLen = pcGammaParam.GammaCurveBufLen,
        pGammaCurveBuf = pcGammaParam.GammaCurveBuf
      });
    }

    /// <summary>Set CCM param</summary>
    /// <param name="pcCCMParam">CCM parameter structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetBayerCCMParam(ref CCCMParam pcCCMParam)
    {
      if (pcCCMParam == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_SetBayerCCMParam(this.handle, ref new MV_CC_CCM_PARAM()
      {
        bCCMEnable = pcCCMParam.CCMEnable,
        nCCMat = pcCCMParam.CCMat
      });
    }

    /// <summary>Set CCM param</summary>
    /// <param name="pcCCMParam">CCM parameter structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetBayerCCMParamEx(ref CCCMParamEx pcCCMParam)
    {
      if (pcCCMParam == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_SetBayerCCMParamEx(this.handle, ref new MV_CC_CCM_PARAM_EX()
      {
        bCCMEnable = pcCCMParam.CCMEnable,
        nCCMat = pcCCMParam.CCMat,
        nCCMScale = pcCCMParam.CCMScale
      });
    }

    /// <summary>High Bandwidth Decode</summary>
    /// <param name="pcDecodeParam">High Bandwidth Decode parameter structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int HB_Decode(ref CDecodeParam pcDecodeParam)
    {
      if (pcDecodeParam == null || IntPtr.Zero == pcDecodeParam.InImage.ImageAddr)
        return -2147483644;
      MV_CC_HB_DECODE_PARAM pstDecodeParam = new MV_CC_HB_DECODE_PARAM();
      uint pixelSize = CInnerTool.GetPixelSize(pcDecodeParam.InImage);
      if (pixelSize == 0U)
        return -2147483647;
      if (pcDecodeParam.OutImage != null)
      {
        int num = pcDecodeParam.OutImage.AllocateUnmanagedMemory(pixelSize);
        if (num != 0)
          return num;
      }
      pstDecodeParam.pSrcBuf = pcDecodeParam.InImage.ImageAddr;
      pstDecodeParam.nSrcLen = pcDecodeParam.InImage.FrameLen;
      pstDecodeParam.pDstBuf = pcDecodeParam.OutImage.ImageAddr;
      pstDecodeParam.nDstBufSize = pcDecodeParam.OutImage.ImageSize;
      int num1 = CCamCtrlRef.MV_CC_HB_Decode(this.handle, ref pstDecodeParam);
      if (num1 != 0)
        return num1;
      pcDecodeParam.OutImage.UpdateImageInfo(pstDecodeParam.pDstBuf, pstDecodeParam.nDstBufLen, (ushort) pstDecodeParam.nHeight, (ushort) pstDecodeParam.nWidth, pstDecodeParam.enDstPixelType, pstDecodeParam.nHeight, pstDecodeParam.nWidth);
      pcDecodeParam.FrameSpecInfo.SecondCount = pstDecodeParam.stFrameSpecInfo.nSecondCount;
      pcDecodeParam.FrameSpecInfo.CycleCount = pstDecodeParam.stFrameSpecInfo.nCycleCount;
      pcDecodeParam.FrameSpecInfo.CycleOffset = pstDecodeParam.stFrameSpecInfo.nCycleOffset;
      pcDecodeParam.FrameSpecInfo.Gain = pstDecodeParam.stFrameSpecInfo.fGain;
      pcDecodeParam.FrameSpecInfo.ExposureTime = pstDecodeParam.stFrameSpecInfo.fExposureTime;
      pcDecodeParam.FrameSpecInfo.AverageBrightness = pstDecodeParam.stFrameSpecInfo.nAverageBrightness;
      pcDecodeParam.FrameSpecInfo.Red = pstDecodeParam.stFrameSpecInfo.nRed;
      pcDecodeParam.FrameSpecInfo.Green = pstDecodeParam.stFrameSpecInfo.nGreen;
      pcDecodeParam.FrameSpecInfo.Blue = pstDecodeParam.stFrameSpecInfo.nBlue;
      pcDecodeParam.FrameSpecInfo.FrameCounter = pstDecodeParam.stFrameSpecInfo.nFrameCounter;
      pcDecodeParam.FrameSpecInfo.TriggerIndex = pstDecodeParam.stFrameSpecInfo.nTriggerIndex;
      pcDecodeParam.FrameSpecInfo.Input = pstDecodeParam.stFrameSpecInfo.nInput;
      pcDecodeParam.FrameSpecInfo.Output = pstDecodeParam.stFrameSpecInfo.nOutput;
      pcDecodeParam.FrameSpecInfo.OffsetX = pstDecodeParam.stFrameSpecInfo.nOffsetX;
      pcDecodeParam.FrameSpecInfo.OffsetY = pstDecodeParam.stFrameSpecInfo.nOffsetY;
      pcDecodeParam.FrameSpecInfo.FrameWidth = pstDecodeParam.stFrameSpecInfo.nFrameWidth;
      pcDecodeParam.FrameSpecInfo.FrameHeight = pstDecodeParam.stFrameSpecInfo.nFrameHeight;
      return 0;
    }

    /// <summary>Save camera feature</summary>
    /// <param name="strFileName">File name</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int FeatureSave(string strFileName) => CCamCtrlRef.MV_CC_FeatureSave(this.handle, strFileName);

    /// <summary>Load camera feature</summary>
    /// <param name="strFileName">File name</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int FeatureLoad(string strFileName) => CCamCtrlRef.MV_CC_FeatureLoad(this.handle, strFileName);

    /// <summary>Read the file from the camera</summary>
    /// <param name="pcFileAccess">File access structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int FileAccessRead(ref CFileAccess pcFileAccess)
    {
      if (pcFileAccess == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_FileAccessRead(this.handle, ref new MV_CC_FILE_ACCESS()
      {
        pDevFileName = pcFileAccess.pDevFileName,
        pUserFileName = pcFileAccess.pUserFileName
      });
    }

    /// <summary>Read the file from the camera</summary>
    /// <param name="pcFileAccessEx">File access structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int FileAccessReadEx(ref CFileAccessEx pcFileAccessEx)
    {
      if (pcFileAccessEx == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_FileAccessReadEx(this.handle, ref new MV_CC_FILE_ACCESS_EX()
      {
        pUserFileBuf = pcFileAccessEx.pUserFileBuf,
        nFileBufSize = pcFileAccessEx.nFileBufSize,
        nFileBufLen = pcFileAccessEx.nFileBufLen,
        pDevFileName = pcFileAccessEx.pDevFileName
      });
    }

    /// <summary>Write the file to camera</summary>
    /// <param name="pcFileAccess">File access structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int FileAccessWrite(ref CFileAccess pcFileAccess)
    {
      if (pcFileAccess == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_FileAccessWrite(this.handle, ref new MV_CC_FILE_ACCESS()
      {
        pDevFileName = pcFileAccess.pDevFileName,
        pUserFileName = pcFileAccess.pUserFileName
      });
    }

    /// <summary>Write the file to camera</summary>
    /// <param name="pcFileAccessEx">File access structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int FileAccessWriteEx(ref CFileAccessEx pcFileAccessEx)
    {
      if (pcFileAccessEx == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_FileAccessWriteEx(this.handle, ref new MV_CC_FILE_ACCESS_EX()
      {
        pUserFileBuf = pcFileAccessEx.pUserFileBuf,
        nFileBufSize = pcFileAccessEx.nFileBufSize,
        nFileBufLen = pcFileAccessEx.nFileBufLen,
        pDevFileName = pcFileAccessEx.pDevFileName
      });
    }

    /// <summary>Get File Access Progress</summary>
    /// <param name="pcFileAccessProgress">File access Progress</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int GetFileAccessProgress(ref CFileAccessProgress pcFileAccessProgress)
    {
      if (pcFileAccessProgress == null)
        return -2147483644;
      MV_CC_FILE_ACCESS_PROGRESS pstFileAccessProgress = new MV_CC_FILE_ACCESS_PROGRESS();
      int fileAccessProgress = CCamCtrlRef.MV_CC_GetFileAccessProgress(this.handle, ref pstFileAccessProgress);
      if (fileAccessProgress != 0)
        return fileAccessProgress;
      pcFileAccessProgress.nCompleted = pstFileAccessProgress.nCompleted;
      pcFileAccessProgress.nTotal = pstFileAccessProgress.nTotal;
      return 0;
    }

    /// <summary>Start Record</summary>
    /// <param name="pcRecordParam">Record param structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int StartRecord(ref CRecordParam pcRecordParam)
    {
      if (pcRecordParam == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_StartRecord(this.handle, ref new MV_CC_RECORD_PARAM()
      {
        enPixelType = pcRecordParam.enPixelType,
        nHeight = Convert.ToUInt16(pcRecordParam.Height),
        nWidth = Convert.ToUInt16(pcRecordParam.Width),
        fFrameRate = pcRecordParam.FrameRate,
        nBitRate = pcRecordParam.BitRate,
        enRecordFmtType = pcRecordParam.RecordFmtType,
        strFilePath = pcRecordParam.FilePath
      });
    }

    /// <summary>Input RAW data to Record</summary>
    /// <param name="pcInputFrameInfo">Record data structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int InputOneFrame(ref CInputFrameInfo pcInputFrameInfo)
    {
      if (pcInputFrameInfo == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_InputOneFrame(this.handle, ref new MV_CC_INPUT_FRAME_INFO()
      {
        pData = pcInputFrameInfo.InImage.ImageAddr,
        nDataLen = pcInputFrameInfo.InImage.FrameLen
      });
    }

    /// <summary>Stop Record</summary>
    /// <returns>Success, return MV_OK. Failure, return error code </returns>
    public int StopRecord() => CCamCtrlRef.MV_CC_StopRecord(this.handle);

    /// <summary>Draw Rect Auxiliary Line</summary>
    /// <param name="pcRectArea">Rect Auxiliary Line Info</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int DrawRect(ref CRectArea pcRectArea)
    {
      if (pcRectArea == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_DrawRect(this.handle, ref new MVCC_RECT_INFO()
      {
        fTop = pcRectArea.Top,
        fBottom = pcRectArea.Bottom,
        fLeft = pcRectArea.Left,
        fRight = pcRectArea.Right,
        nLineWidth = pcRectArea.LineWidth,
        stColor = {
          fR = pcRectArea.Color.Red,
          fG = pcRectArea.Color.Green,
          fB = pcRectArea.Color.Blue,
          fAlpha = pcRectArea.Color.Alpha
        }
      });
    }

    /// <summary>Draw Circle Auxiliary Line</summary>
    /// <param name="pcCircleArea">Circle Auxiliary Line Info</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int DrawCircle(ref CCircleArea pcCircleArea)
    {
      if (pcCircleArea == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_DrawCircle(this.handle, ref new MVCC_CIRCLE_INFO()
      {
        fR1 = pcCircleArea.R1,
        fR2 = pcCircleArea.R2,
        nLineWidth = pcCircleArea.LineWidth,
        stColor = {
          fR = pcCircleArea.Color.Red,
          fG = pcCircleArea.Color.Green,
          fB = pcCircleArea.Color.Blue,
          fAlpha = pcCircleArea.Color.Alpha
        },
        stCenterPoint = {
          fX = pcCircleArea.CenterPoint.X,
          fY = pcCircleArea.CenterPoint.Y
        }
      });
    }

    /// <summary>Draw Line Auxiliary Line</summary>
    /// <param name="pcLinesArea">Linear Auxiliary Line Info</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int DrawLines(ref CLinesArea pcLinesArea)
    {
      if (pcLinesArea == null)
        return -2147483644;
      return CCamCtrlRef.MV_CC_DrawLines(this.handle, ref new MVCC_LINES_INFO()
      {
        nLineWidth = pcLinesArea.LineWidth,
        stColor = {
          fR = pcLinesArea.Color.Red,
          fG = pcLinesArea.Color.Green,
          fB = pcLinesArea.Color.Blue,
          fAlpha = pcLinesArea.Color.Alpha
        },
        stStartPoint = {
          fX = pcLinesArea.StartPoint.X,
          fY = pcLinesArea.StartPoint.Y
        },
        stEndPoint = {
          fX = pcLinesArea.EndPoint.X,
          fY = pcLinesArea.EndPoint.Y
        }
      });
    }

    /// <summary>
    /// Restructure Image(For time-division exposure function)
    /// </summary>
    /// <param name="pcReconstructParam">Restructure image parameters</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int ReconstructImage(ref CReconstructImageParam pcReconstructParam)
    {
      if (pcReconstructParam == null)
        return -2147483644;
      MV_RECONSTRUCT_IMAGE_PARAM pstReconstructParam = new MV_RECONSTRUCT_IMAGE_PARAM();
      pstReconstructParam.stDstBufList = new MV_OUTPUT_IMAGE_INFO[8];
      if (pcReconstructParam.InImage.Width >= ushort.MaxValue || pcReconstructParam.InImage.Height >= ushort.MaxValue)
      {
        pstReconstructParam.nWidth = pcReconstructParam.InImage.ExtendWidth;
        pstReconstructParam.nHeight = pcReconstructParam.InImage.ExtendHeight;
      }
      else
      {
        pstReconstructParam.nWidth = (uint) pcReconstructParam.InImage.Width;
        pstReconstructParam.nHeight = (uint) pcReconstructParam.InImage.Height;
      }
      pstReconstructParam.enPixelType = pcReconstructParam.InImage.PixelType;
      pstReconstructParam.pSrcData = pcReconstructParam.InImage.ImageAddr;
      pstReconstructParam.nSrcDataLen = pcReconstructParam.InImage.FrameLen;
      pstReconstructParam.nExposureNum = pcReconstructParam.ExposureNum;
      pstReconstructParam.enReconstructMethod = pcReconstructParam.ReconstructMethod;
      for (uint index = 0; index < pstReconstructParam.nExposureNum; ++index)
      {
        pcReconstructParam.OutImages[(int) index] = new CImage();
        if (pcReconstructParam.OutImages[(int) index] != null)
        {
          int num = pcReconstructParam.OutImages[(int) index].AllocateUnmanagedMemory(pcReconstructParam.InImage.FrameLen / pcReconstructParam.ExposureNum);
          if (num != 0)
            return num;
        }
        pstReconstructParam.stDstBufList[(int) index].pBuf = pcReconstructParam.OutImages[(int) index].ImageAddr;
        pstReconstructParam.stDstBufList[(int) index].nBufSize = pcReconstructParam.InImage.FrameLen / pcReconstructParam.ExposureNum;
      }
      int num1 = CCamCtrlRef.MV_CC_ReconstructImage(this.handle, ref pstReconstructParam);
      if (num1 != 0)
        return num1;
      for (uint index = 0; index < pstReconstructParam.nExposureNum; ++index)
        pcReconstructParam.OutImages[(int) index].UpdateImageInfo(pstReconstructParam.stDstBufList[(int) index].pBuf, pstReconstructParam.stDstBufList[(int) index].nBufLen, (ushort) pstReconstructParam.stDstBufList[(int) index].nHeight, (ushort) pstReconstructParam.stDstBufList[(int) index].nWidth, pstReconstructParam.stDstBufList[(int) index].enPixelType, pstReconstructParam.stDstBufList[(int) index].nHeight, pstReconstructParam.stDstBufList[(int) index].nWidth);
      return 0;
    }

    /// <summary>
    /// Filter type of the bell interpolation quality algorithm setting
    /// </summary>
    /// <param name="bFilterEnable">Filter type enable</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int SetBayerFilterEnable(bool bFilterEnable) => CCamCtrlRef.MV_CC_SetBayerFilterEnable(this.handle, bFilterEnable);

    /// <summary>Adjust image contrast</summary>
    /// <param name="pcContrastParam">Contrast parameter structure</param>
    /// <returns>Success, return MV_OK. Failure, return error code</returns>
    public int ImageContrast(ref CContrastParam pcContrastParam)
    {
      if (pcContrastParam == null || IntPtr.Zero == pcContrastParam.InImage.ImageAddr)
        return -2147483644;
      MV_CC_CONTRAST_PARAM pstContrastParam = new MV_CC_CONTRAST_PARAM();
      uint pixelSize;
      if (pcContrastParam.InImage.Width >= ushort.MaxValue || pcContrastParam.InImage.Height >= ushort.MaxValue)
      {
        pixelSize = CInnerTool.GetPixelSize(pcContrastParam.InImage);
        pstContrastParam.nWidth = pcContrastParam.InImage.ExtendWidth;
        pstContrastParam.nHeight = pcContrastParam.InImage.ExtendHeight;
      }
      else
      {
        pixelSize = CInnerTool.GetPixelSize(pcContrastParam.InImage);
        pstContrastParam.nWidth = (uint) pcContrastParam.InImage.Width;
        pstContrastParam.nHeight = (uint) pcContrastParam.InImage.Height;
      }
      if (pcContrastParam.OutImage != null)
      {
        int num = pcContrastParam.OutImage.AllocateUnmanagedMemory(pixelSize);
        if (num != 0)
          return num;
      }
      pstContrastParam.pSrcBuf = pcContrastParam.InImage.ImageAddr;
      pstContrastParam.nSrcBufLen = pcContrastParam.InImage.FrameLen;
      pstContrastParam.enPixelType = pcContrastParam.InImage.PixelType;
      pstContrastParam.pDstBuf = pcContrastParam.OutImage.ImageAddr;
      pstContrastParam.nDstBufSize = pcContrastParam.OutImage.ImageSize;
      pstContrastParam.nContrastFactor = pcContrastParam.ContrastFactor;
      int num1 = CCamCtrlRef.MV_CC_ImageContrast(this.handle, ref pstContrastParam);
      if (num1 != 0)
        return num1;
      pcContrastParam.OutImage.UpdateImageInfo(pstContrastParam.pDstBuf, pstContrastParam.nDstBufLen, (ushort) pstContrastParam.nHeight, (ushort) pstContrastParam.nWidth, pstContrastParam.enPixelType, pstContrastParam.nHeight, pstContrastParam.nWidth);
      return 0;
    }

    /// <summary>callback image data converted to bitmap</summary>
    /// <param name="pData">callback image data</param>
    /// <param name="pFrameInfo">image info</param>
    /// <returns>Success, return bitmap. Failure, return null</returns>
    public Bitmap ImageToBitmap(IntPtr pData, ref MV_FRAME_OUT_INFO_EX pFrameInfo) => pFrameInfo.nWidth >= ushort.MaxValue || pFrameInfo.nHeight >= ushort.MaxValue ? this.ConvertToBitmap(pData, pFrameInfo.nFrameLen, pFrameInfo.nExtendWidth, pFrameInfo.nExtendHeight, pFrameInfo.enPixelType) : this.ConvertToBitmap(pData, pFrameInfo.nFrameLen, (uint) pFrameInfo.nWidth, (uint) pFrameInfo.nHeight, pFrameInfo.enPixelType);

    /// <summary>
    /// The timeout mechanism obtains a frame of image data to Bitmap
    /// </summary>
    /// <param name="pData">image data buffer</param>
    /// <param name="pcFrameEx">image info</param>
    /// <returns>Success, return bitmap. Failure, return null</returns>
    public Bitmap ImageToBitmap(byte[] pData, ref CFrameoutEx pcFrameEx)
    {
      if (pData == null || 0U >= pcFrameEx.pcImageInfoEx.FrameLen)
        return (Bitmap) null;
      IntPtr num = Marshal.AllocHGlobal((int) pcFrameEx.pcImageInfoEx.FrameLen);
      if (num == IntPtr.Zero)
        return (Bitmap) null;
      try
      {
        Marshal.Copy(pData, 0, num, (int) pcFrameEx.pcImageInfoEx.FrameLen);
        return pcFrameEx.pcImageInfoEx.Width >= ushort.MaxValue || pcFrameEx.pcImageInfoEx.Height >= ushort.MaxValue ? this.ConvertToBitmap(num, pcFrameEx.pcImageInfoEx.FrameLen, pcFrameEx.pcImageInfoEx.nExtendWidth, pcFrameEx.pcImageInfoEx.nExtendHeight, pcFrameEx.pcImageInfoEx.PixelType) : this.ConvertToBitmap(num, pcFrameEx.pcImageInfoEx.FrameLen, (uint) pcFrameEx.pcImageInfoEx.Width, (uint) pcFrameEx.pcImageInfoEx.Height, pcFrameEx.pcImageInfoEx.PixelType);
      }
      finally
      {
        Marshal.FreeHGlobal(num);
      }
    }

    /// <summary>
    /// The internal cache obtains a frame of image data to convert to Bitmap
    /// </summary>
    /// <param name="pcFrame">image data</param>
    /// <returns>Success, return bitmap. Failure, return null</returns>
    public Bitmap ImageToBitmap(ref CFrameout pcFrame)
    {
      if (pcFrame != null)
      {
        IntPtr imageAddr = pcFrame.Image.ImageAddr;
        if (0U < pcFrame.Image.FrameLen)
          return pcFrame.Image.Width >= ushort.MaxValue || pcFrame.Image.Height >= ushort.MaxValue ? this.ConvertToBitmap(pcFrame.Image.ImageAddr, pcFrame.Image.FrameLen, pcFrame.Image.ExtendWidth, pcFrame.Image.ExtendHeight, pcFrame.Image.PixelType) : this.ConvertToBitmap(pcFrame.Image.ImageAddr, pcFrame.Image.FrameLen, (uint) pcFrame.Image.Width, (uint) pcFrame.Image.Height, pcFrame.Image.PixelType);
      }
      return (Bitmap) null;
    }

    /// <summary>raw frame data converted to bitmap</summary>
    /// <param name="pData">raw frame data</param>
    /// <param name="nFrameLen">image data len</param>
    /// <param name="nImageWidth">image width</param>
    /// <param name="nImageHeight">image height</param>
    /// <param name="enPixelType">image pixel</param>
    /// <returns>Success, return bitmap. Failure, return null</returns>
    private Bitmap ConvertToBitmap(
      IntPtr pData,
      uint nFrameLen,
      uint nImageWidth,
      uint nImageHeight,
      MvGvspPixelType enPixelType)
    {
      if (IntPtr.Zero == pData || MvGvspPixelType.PixelType_Gvsp_Undefined == enPixelType)
        return (Bitmap) null;
      MV_PIXEL_CONVERT_PARAM pstCvtParam = new MV_PIXEL_CONVERT_PARAM();
      int num = (int) nImageWidth;
      MvGvspPixelType enType;
      PixelFormat format;
      if (CInnerTool.IsMonoPixel(enPixelType))
      {
        enType = MvGvspPixelType.PixelType_Gvsp_Mono8;
        format = PixelFormat.Format8bppIndexed;
      }
      else
      {
        enType = MvGvspPixelType.PixelType_Gvsp_BGR8_Packed;
        format = PixelFormat.Format24bppRgb;
        num = (int) nImageWidth * 3;
      }
      Bitmap bitmap;
      if (PixelFormat.Format8bppIndexed == format)
      {
        bitmap = new Bitmap((int) nImageWidth, (int) nImageHeight, format);
        ColorPalette palette = bitmap.Palette;
        for (int index = 0; index < palette.Entries.Length; ++index)
          palette.Entries[index] = Color.FromArgb(index, index, index);
        bitmap.Palette = palette;
      }
      else
        bitmap = new Bitmap((int) nImageWidth, (int) nImageHeight, format);
      uint pixelSize = CInnerTool.GetPixelSize(enType, nImageWidth, nImageHeight);
      IntPtr hglobal = Marshal.AllocHGlobal((int) pixelSize);
      if (hglobal == IntPtr.Zero)
        return bitmap;
      try
      {
        pstCvtParam.nWidth = (ushort) nImageWidth;
        pstCvtParam.nHeight = (ushort) nImageHeight;
        pstCvtParam.enSrcPixelType = enPixelType;
        pstCvtParam.pSrcData = pData;
        pstCvtParam.nSrcDataLen = nFrameLen;
        pstCvtParam.enDstPixelType = enType;
        pstCvtParam.pDstBuffer = hglobal;
        pstCvtParam.nDstBufferSize = pixelSize;
        if (CCamCtrlRef.MV_CC_ConvertPixelType(this.handle, ref pstCvtParam) != 0)
          return bitmap;
        BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
        IntPtr scan0 = bitmapdata.Scan0;
        if (num == bitmapdata.Stride)
        {
          uint count = (uint) (bitmapdata.Stride * bitmap.Height);
          CCamera.CopyMemory(scan0, pstCvtParam.pDstBuffer, count);
        }
        else
        {
          for (int index = 0; index < bitmap.Height; ++index)
            CCamera.CopyMemory(new IntPtr(scan0.ToInt64() + (long) (index * bitmapdata.Stride)), new IntPtr(pstCvtParam.pDstBuffer.ToInt64() + (long) (index * num)), nImageWidth);
        }
        bitmap.UnlockBits(bitmapdata);
        return bitmap;
      }
      finally
      {
        Marshal.FreeHGlobal(hglobal);
      }
    }

    /// <summary>
    /// Set SDK log path (Interfaces not recommended)
    /// If the logging service MvLogServer is enabled, the interface is invalid and The logging service is enabled by default
    /// </summary>
    /// <param name="strSDKLogPath"></param>
    /// <returns></returns>
    public int SetSDKLogPath(string strSDKLogPath) => CCamCtrlRef.MV_CC_SetSDKLogPath(strSDKLogPath);
  }
}
