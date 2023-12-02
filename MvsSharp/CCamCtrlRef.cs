// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CCamCtrlRef
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Runtime.InteropServices;
using MvsSharp.CameraParams;

namespace MvsSharp
{
  /// <summary>从C/C++接口库导出的函数的类</summary>
  internal class CCamCtrlRef
  {
    [DllImport("MvCameraControl.dll")]
    public static extern uint MV_CC_GetSDKVersion();

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_EnumerateTls();

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_EnumDevices(
      uint nTLayerType,
      ref MV_CC_DEVICE_INFO_LIST stDevList);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_EnumDevicesEx(
      uint nTLayerType,
      ref MV_CC_DEVICE_INFO_LIST stDevList,
      string pManufacturerName);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_EnumDevicesEx2(
      uint nTLayerType,
      ref MV_CC_DEVICE_INFO_LIST stDevList,
      string pManufacturerName,
      MV_SORT_METHOD enSortMethod);

    [DllImport("MvCameraControl.dll")]
    public static extern bool MV_CC_IsDeviceAccessible(
      ref MV_CC_DEVICE_INFO stDevInfo,
      uint nAccessMode);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetSDKLogPath(string pSDKLogPath);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_CreateHandle(ref IntPtr handle, ref MV_CC_DEVICE_INFO stDevInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_CreateHandleWithoutLog(
      ref IntPtr handle,
      ref MV_CC_DEVICE_INFO stDevInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_DestroyHandle(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_OpenDevice(
      IntPtr handle,
      uint nAccessMode,
      ushort nSwitchoverKey);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_CloseDevice(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern bool MV_CC_IsDeviceConnected(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RegisterImageCallBackEx(
      IntPtr handle,
      cbOutputExdelegate cbOutput,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RegisterImageCallBackForRGB(
      IntPtr handle,
      cbOutputExdelegate cbOutput,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RegisterImageCallBackForBGR(
      IntPtr handle,
      cbOutputExdelegate cbOutput,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_StartGrabbing(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_StopGrabbing(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetImageForRGB(
      IntPtr handle,
      IntPtr pData,
      uint nDataSize,
      ref MV_FRAME_OUT_INFO_EX pFrameInfo,
      int nMsec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetImageForBGR(
      IntPtr handle,
      IntPtr pData,
      uint nDataSize,
      ref MV_FRAME_OUT_INFO_EX pFrameInfo,
      int nMsec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetImageBuffer(
      IntPtr handle,
      ref MV_FRAME_OUT pFrame,
      int nMsec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_FreeImageBuffer(IntPtr handle, ref MV_FRAME_OUT pFrame);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetOneFrameTimeout(
      IntPtr handle,
      IntPtr pData,
      uint nDataSize,
      ref MV_FRAME_OUT_INFO_EX pFrameInfo,
      int nMsec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_ClearImageBuffer(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetValidImageNum(IntPtr handle, ref uint pnValidImageNum);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_DisplayOneFrame(
      IntPtr handle,
      ref MV_DISPLAY_FRAME_INFO pDisplayInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_DisplayOneFrameEx(
      IntPtr handle,
      IntPtr hWnd,
      ref MV_DISPLAY_FRAME_INFO_EX pDisplayInfoEx);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetImageNodeNum(IntPtr handle, uint nNum);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetGrabStrategy(IntPtr handle, MV_GRAB_STRATEGY enGrabStrategy);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetOutputQueueSize(IntPtr handle, uint nOutputQueueSize);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetDeviceInfo(IntPtr handle, ref MV_CC_DEVICE_INFO pstDevInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetAllMatchInfo(IntPtr handle, ref MV_ALL_MATCH_INFO pstInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetIntValueEx(
      IntPtr handle,
      string strValue,
      ref MVCC_INTVALUE_EX pIntValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetIntValueEx(IntPtr handle, string strValue, long nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetEnumValue(
      IntPtr handle,
      string strValue,
      ref MVCC_ENUMVALUE pEnumValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetEnumValue(IntPtr handle, string strValue, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetEnumEntrySymbolic(
      IntPtr handle,
      string strKey,
      ref MVCC_ENUMENTRY pstEnumEntry);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetEnumValueByString(
      IntPtr handle,
      string strValue,
      string sValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetFloatValue(
      IntPtr handle,
      string strValue,
      ref MVCC_FLOATVALUE pFloatValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetFloatValue(IntPtr handle, string strValue, float fValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetBoolValue(
      IntPtr handle,
      string strValue,
      ref bool pBoolValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBoolValue(IntPtr handle, string strValue, bool bValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetStringValue(
      IntPtr handle,
      string strKey,
      ref MVCC_STRINGVALUE pStringValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetStringValue(IntPtr handle, string strKey, string sValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetCommandValue(IntPtr handle, string strValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_InvalidateNodes(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_LocalUpgrade(IntPtr handle, string pFilePathName);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetUpgradeProcess(IntPtr handle, ref uint pnProcess);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_ReadMemory(
      IntPtr handle,
      IntPtr pBuffer,
      long nAddress,
      long nLength);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_WriteMemory(
      IntPtr handle,
      IntPtr pBuffer,
      long nAddress,
      long nLength);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RegisterExceptionCallBack(
      IntPtr handle,
      cbExceptiondelegate cbException,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RegisterEventCallBack(
      IntPtr handle,
      cbEventdelegate cbEvent,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RegisterAllEventCallBack(
      IntPtr handle,
      cbEventdelegateEx cbEvent,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RegisterEventCallBackEx(
      IntPtr handle,
      string pEventName,
      cbEventdelegateEx cbEvent,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetEnumDevTimeout(uint nMilTimeout);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_ForceIpEx(
      IntPtr handle,
      uint nIP,
      uint nSubNetMask,
      uint nDefaultGateWay);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetIpConfig(IntPtr handle, uint nType);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetNetTransMode(IntPtr handle, uint nType);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetNetTransInfo(IntPtr handle, ref MV_NETTRANS_INFO pstInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetDiscoveryMode(uint nMode);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetGvspTimeout(IntPtr handle, uint nMillisec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetGvspTimeout(IntPtr handle, ref uint pMillisec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetGvcpTimeout(IntPtr handle, uint nMillisec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetGvcpTimeout(IntPtr handle, ref uint pMillisec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetRetryGvcpTimes(IntPtr handle, uint nRetryGvcpTimes);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetRetryGvcpTimes(IntPtr handle, ref uint pRetryGvcpTimes);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetOptimalPacketSize(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetResend(
      IntPtr handle,
      uint bEnable,
      uint nMaxResendPercent,
      uint nResendTimeout);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetResendMaxRetryTimes(IntPtr handle, uint nRetryTimes);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetResendMaxRetryTimes(IntPtr handle, ref uint pnRetryTimes);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetResendTimeInterval(IntPtr handle, uint nMillisec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetResendTimeInterval(IntPtr handle, ref uint pnMillisec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetTransmissionType(
      IntPtr handle,
      ref MV_CC_TRANSMISSION_TYPE pstTransmissionType);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_IssueActionCommand(
      ref MV_ACTION_CMD_INFO pstActionCmdInfo,
      ref MV_ACTION_CMD_RESULT_LIST pstActionCmdResults);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetMulticastStatus(
      ref MV_CC_DEVICE_INFO pstDevInfo,
      ref bool pStatus);

    [DllImport("MvCameraControl.dll", EntryPoint = "MV_CAML_SetDeviceBauderate")]
    public static extern int MV_CAML_SetDeviceBaudrate(IntPtr handle, uint nBaudrate);

    [DllImport("MvCameraControl.dll", EntryPoint = "MV_CAML_GetDeviceBauderate")]
    public static extern int MV_CAML_GetDeviceBaudrate(IntPtr handle, ref uint pnCurrentBaudrate);

    [DllImport("MvCameraControl.dll", EntryPoint = "MV_CAML_GetSupportBauderates")]
    public static extern int MV_CAML_GetSupportBaudrates(IntPtr handle, ref uint pnBaudrateAblity);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CAML_SetGenCPTimeOut(IntPtr handle, uint nMillisec);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_USB_SetTransferSize(IntPtr handle, uint nTransferSize);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_USB_GetTransferSize(IntPtr handle, ref uint pTransferSize);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_USB_SetTransferWays(IntPtr handle, uint nTransferWays);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_USB_GetTransferWays(IntPtr handle, ref uint pTransferWays);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_USB_RegisterStreamExceptionCallBack(
      IntPtr handle,
      cbStreamExceptiondelegate cbException,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_USB_SetEventNodeNum(IntPtr handle, uint nEventNodeNum);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_USB_SetSyncTimeOut(IntPtr handle, uint nMills);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_USB_GetSyncTimeOut(IntPtr handle, ref uint pnMills);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_EnumInterfacesByGenTL(
      ref MV_GENTL_IF_INFO_LIST pstIFInfoList,
      string sGenTLPath);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_EnumDevicesByGenTL(
      ref MV_GENTL_IF_INFO stIFInfo,
      ref MV_GENTL_DEV_INFO_LIST pstDevList);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_UnloadGenTLLibrary(string strGenTLPath);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_CreateHandleByGenTL(
      ref IntPtr handle,
      ref MV_GENTL_DEV_INFO stDevInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_GetGenICamXML(
      IntPtr handle,
      IntPtr pData,
      uint nDataSize,
      ref uint pnDataLen);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_GetNodeAccessMode(
      IntPtr handle,
      string pstrName,
      ref MV_XML_AccessMode pAccessMode);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_GetNodeInterfaceType(
      IntPtr handle,
      string pstrName,
      ref MV_XML_InterfaceType pInterfaceType);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_GetRootNode(IntPtr handle, ref MV_XML_NODE_FEATURE pstNode);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_GetChildren(
      IntPtr handle,
      ref MV_XML_NODE_FEATURE pstNode,
      IntPtr pstNodesList);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_GetChildren(
      IntPtr handle,
      ref MV_XML_NODE_FEATURE pstNode,
      ref MV_XML_NODES_LIST pstNodesList);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_GetNodeFeature(
      IntPtr handle,
      ref MV_XML_NODE_FEATURE pstNode,
      IntPtr pstFeature);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_UpdateNodeFeature(
      IntPtr handle,
      MV_XML_InterfaceType enType,
      IntPtr pstFeature);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_XML_RegisterUpdateCallBack(
      IntPtr handle,
      cbXmlUpdatedelegate cbXmlUpdate,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SaveImageEx3(
      IntPtr handle,
      ref MV_SAVE_IMAGE_PARAM_EX2 stSaveParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SaveImageToFileEx(
      IntPtr handle,
      ref MV_SAVE_IMG_TO_FILE_PARAM_EX pstSaveFileParamEx);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SavePointCloudData(
      IntPtr handle,
      ref MV_SAVE_POINT_CLOUD_PARAM pstPointDataParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RotateImage(
      IntPtr handle,
      ref MV_CC_ROTATE_IMAGE_PARAM pstRotateParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_FlipImage(IntPtr handle, ref MV_CC_FLIP_IMAGE_PARAM pstFlipParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_ConvertPixelTypeEx(
      IntPtr handle,
      ref MV_PIXEL_CONVERT_PARAM_EX pstCvtParamEx);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetGammaValue(
      IntPtr handle,
      MvGvspPixelType enSrcPixelType,
      float fGammaValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBayerCvtQuality(IntPtr handle, uint BayerCvtQuality);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBayerFilterEnable(IntPtr handle, bool bFilterEnable);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBayerGammaParam(
      IntPtr handle,
      ref MV_CC_GAMMA_PARAM pstGammaParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBayerCCMParam(IntPtr handle, ref MV_CC_CCM_PARAM pstCCMParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBayerCCMParamEx(
      IntPtr handle,
      ref MV_CC_CCM_PARAM_EX pstCCMParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_ImageContrast(
      IntPtr handle,
      ref MV_CC_CONTRAST_PARAM pstContrastParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_HB_Decode(
      IntPtr handle,
      ref MV_CC_HB_DECODE_PARAM pstDecodeParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_DrawRect(IntPtr handle, ref MVCC_RECT_INFO pRectInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_DrawCircle(IntPtr handle, ref MVCC_CIRCLE_INFO pCircleInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_DrawLines(IntPtr handle, ref MVCC_LINES_INFO pLinesInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_FeatureSave(IntPtr handle, string pFileName);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_FeatureLoad(IntPtr handle, string pFileName);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_FileAccessRead(
      IntPtr handle,
      ref MV_CC_FILE_ACCESS pstFileAccess);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_FileAccessReadEx(
      IntPtr handle,
      ref MV_CC_FILE_ACCESS_EX pstFileAccessEx);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_FileAccessWrite(
      IntPtr handle,
      ref MV_CC_FILE_ACCESS pstFileAccess);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_FileAccessWriteEx(
      IntPtr handle,
      ref MV_CC_FILE_ACCESS_EX pstFileAccessEx);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetFileAccessProgress(
      IntPtr handle,
      ref MV_CC_FILE_ACCESS_PROGRESS pstFileAccessProgress);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_StartRecord(IntPtr handle, ref MV_CC_RECORD_PARAM pstRecordParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_InputOneFrame(
      IntPtr handle,
      ref MV_CC_INPUT_FRAME_INFO pstInputFrameInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_StopRecord(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_OpenParamsGUI(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_ReconstructImage(
      IntPtr handle,
      ref MV_RECONSTRUCT_IMAGE_PARAM pstReconstructParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SaveImageEx2(
      IntPtr handle,
      ref MV_SAVE_IMAGE_PARAM_EX stSaveParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SaveImageToFile(
      IntPtr handle,
      ref MV_SAVE_IMG_TO_FILE_PARAM pstSaveFileParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_ConvertPixelType(
      IntPtr handle,
      ref MV_PIXEL_CONVERT_PARAM pstCvtParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetOneFrame(
      IntPtr handle,
      IntPtr pData,
      uint nDataSize,
      ref MV_FRAME_OUT_INFO pFrameInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetOneFrameEx(
      IntPtr handle,
      IntPtr pData,
      uint nDataSize,
      ref MV_FRAME_OUT_INFO_EX pFrameInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_RegisterImageCallBack(
      IntPtr handle,
      cbOutputdelegate cbOutput,
      IntPtr pUser);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SaveImage(ref MV_SAVE_IMAGE_PARAM stSaveParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_ForceIp(IntPtr handle, uint nIP);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_BayerNoiseEstimate(
      IntPtr handle,
      ref MV_CC_BAYER_NOISE_ESTIMATE_PARAM pstNoiseEstimateParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_BayerSpatialDenoise(
      IntPtr handle,
      ref MV_CC_BAYER_SPATIAL_DENOISE_PARAM pstSpatialDenoiseParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_Display(IntPtr handle, IntPtr hWnd);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetImageInfo(IntPtr handle, ref MV_IMAGE_BASIC_INFO pstInfo);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetGevSCPSPacketSize(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetGevSCPSPacketSize(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetGevSCPD(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetGevSCPD(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetGevSCDA(IntPtr handle, ref uint pnIP);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetGevSCDA(IntPtr handle, uint nIP);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_GetGevSCSP(IntPtr handle, ref uint pnPort);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_GIGE_SetGevSCSP(IntPtr handle, uint nPort);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBayerCLUTParam(
      IntPtr handle,
      ref MV_CC_CLUT_PARAM pstCLUTParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_ImageSharpen(
      IntPtr handle,
      ref MV_CC_SHARPEN_PARAM pstSharpenParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_ColorCorrect(
      IntPtr handle,
      ref MV_CC_COLOR_CORRECT_PARAM pstColorCorrectParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_NoiseEstimate(
      IntPtr handle,
      ref MV_CC_NOISE_ESTIMATE_PARAM pstNoiseEstimateParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SpatialDenoise(
      IntPtr handle,
      ref MV_CC_SPATIAL_DENOISE_PARAM pstSpatialDenoiseParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_LSCCalib(
      IntPtr handle,
      ref MV_CC_LSC_CALIB_PARAM pstLSCCalibParam);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_LSCCorrect(
      IntPtr handle,
      ref MV_CC_LSC_CORRECT_PARAM pstLSCCorrectParam);

    [DllImport("MvCameraControl.dll")]
    public static extern IntPtr MV_CC_GetTlProxy(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_WriteLog(string strLog);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetIntValue(
      IntPtr handle,
      string strValue,
      ref MVCC_INTVALUE pIntValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetIntValue(IntPtr handle, string strValue, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetWidth(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetWidth(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetHeight(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetHeight(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetAOIoffsetX(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetAOIoffsetX(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetAOIoffsetY(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetAOIoffsetY(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetAutoExposureTimeLower(
      IntPtr handle,
      ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetAutoExposureTimeLower(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetAutoExposureTimeUpper(
      IntPtr handle,
      ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetAutoExposureTimeUpper(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetBrightness(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBrightness(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetFrameRate(IntPtr handle, ref MVCC_FLOATVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetFrameRate(IntPtr handle, float fValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetGain(IntPtr handle, ref MVCC_FLOATVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetGain(IntPtr handle, float fValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetExposureTime(IntPtr handle, ref MVCC_FLOATVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetExposureTime(IntPtr handle, float fValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetPixelFormat(IntPtr handle, ref MVCC_ENUMVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetPixelFormat(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetAcquisitionMode(IntPtr handle, ref MVCC_ENUMVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetAcquisitionMode(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetGainMode(IntPtr handle, ref MVCC_ENUMVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetGainMode(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetExposureAutoMode(IntPtr handle, ref MVCC_ENUMVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetExposureAutoMode(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetTriggerMode(IntPtr handle, ref MVCC_ENUMVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetTriggerMode(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetTriggerDelay(IntPtr handle, ref MVCC_FLOATVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetTriggerDelay(IntPtr handle, float fValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetTriggerSource(IntPtr handle, ref MVCC_ENUMVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetTriggerSource(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_TriggerSoftwareExecute(IntPtr handle);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetGammaSelector(IntPtr handle, ref MVCC_ENUMVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetGammaSelector(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetGamma(IntPtr handle, ref MVCC_FLOATVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetGamma(IntPtr handle, float fValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetSharpness(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetSharpness(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetHue(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetHue(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetSaturation(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetSaturation(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetBalanceWhiteAuto(IntPtr handle, ref MVCC_ENUMVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBalanceWhiteAuto(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetBalanceRatioRed(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBalanceRatioRed(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetBalanceRatioGreen(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBalanceRatioGreen(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetBalanceRatioBlue(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBalanceRatioBlue(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetDeviceUserID(IntPtr handle, ref MVCC_STRINGVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetDeviceUserID(IntPtr handle, string chValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetBurstFrameCount(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBurstFrameCount(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetAcquisitionLineRate(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetAcquisitionLineRate(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_GetHeartBeatTimeout(IntPtr handle, ref MVCC_INTVALUE pstValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetHeartBeatTimeout(IntPtr handle, uint nValue);

    [DllImport("MvCameraControl.dll")]
    public static extern int MV_CC_SetBayerGammaValue(IntPtr handle, float fBayerGammaValue);
  }
}
