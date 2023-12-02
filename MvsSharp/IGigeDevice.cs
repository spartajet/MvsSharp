// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.IGigeDevice
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>GigEVision 设备独有的接口</summary>
  public interface IGigeDevice : IDevice
  {
    /// <summary>强制IP</summary>
    /// <param name="nIP">设置的IP</param>
    /// <param name="nSubNetMask">子网掩码</param>
    /// <param name="nDefaultGateWay">默认网关</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_ForceIpEx(uint nIP, uint nSubNetMask, uint nDefaultGateWay);

    /// <summary>配置IP方式</summary>
    /// <param name="enType">IP类型</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_SetIpConfig(MV_GIGE_IP_CONFIG_TYPE enType);

    /// <summary>设置仅使用某种模式,type: MV_NET_TRANS_x，不设置时，默认优先使用driver</summary>
    /// <param name="enType">网络传输模式</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_SetNetTransMode(MV_GIGE_Net_Transfer_Mode enType);

    /// <summary>获取网络传输信息</summary>
    /// <param name="pcNetTransInfo">网络传输信息</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_GetNetTransInfo(ref CNetTransInfo pcNetTransInfo);

    /// <summary>设置GVSP取流超时时间</summary>
    /// <param name="nMillisec">超时时间，默认300ms，范围：&gt;10ms</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_SetGvspTimeout(uint nMillisec);

    /// <summary>获取GVSP取流超时时间</summary>
    /// <param name="pMillisec">超时时间，以毫秒位单位</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_GetGvspTimeout(ref uint pMillisec);

    /// <summary>设置GVCP命令超时时间</summary>
    /// <param name="nMillisec">超时时间，默认500ms，范围：0-10000ms</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_SetGvcpTimeout(uint nMillisec);

    /// <summary>获取GVCP命令超时时间</summary>
    /// <param name="pMillisec">超时时间，以毫秒位单位</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_GetGvcpTimeout(ref uint pMillisec);

    /// <summary>设置重传GVCP命令次数</summary>
    /// <param name="nRetryGvcpTimes">重传次数，范围：0-100</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GIGE_SetRetryGvcpTimes(uint nRetryGvcpTimes);

    /// <summary>获取重传GVCP命令次数</summary>
    /// <param name="pnRetryGvcpTimes">重传次数，默认3次</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_GetRetryGvcpTimes(ref uint pnRetryGvcpTimes);

    /// <summary>获取最佳的packet size，该接口目前只支持GigE设备</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_GetOptimalPacketSize();

    /// <summary>设置是否打开重发包支持，及重发包设置</summary>
    /// <param name="bEnable">是否支持重发包</param>
    /// <param name="nMaxResendPercent">最大重发比</param>
    /// <param name="nResendTimeout">重发超时时间</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_SetResend(uint bEnable, uint nMaxResendPercent, uint nResendTimeout);

    /// <summary>设置重传命令最大尝试次数</summary>
    /// <param name="nRetryTimes">重传命令最大尝试次数，默认20</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_SetResendMaxRetryTimes(uint nRetryTimes);

    /// <summary>获取重传命令最大尝试次数</summary>
    /// <param name="pnRetryTimes">重传命令最大尝试次数</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_GetResendMaxRetryTimes(ref uint pnRetryTimes);

    /// <summary>设置同一重传包多次请求之间的时间间隔</summary>
    /// <param name="nMillisec">同一重传包多次请求之间的时间间隔，默认10ms</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_SetResendTimeInterval(uint nMillisec);

    /// <summary>获取同一重传包多次请求之间的时间间隔</summary>
    /// <param name="pnMillisec">同一重传包多次请求之间的时间间隔</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_GetResendTimeInterval(ref uint pnMillisec);

    /// <summary>设置传输模式，可以为单播模式、组播模式等</summary>
    /// <param name="pcTransmissionType">传输模式</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_SetTransmissionType(ref CTransMissionType pcTransmissionType);

    /// <summary>发出动作命令</summary>
    /// <param name="pcActionCmdInfo">动作命令信息</param>
    /// <param name="pcActionCmdResults">动作命令返回信息列表</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_IssueActionCommand(
      ref CActionCmdInfo pcActionCmdInfo,
      ref CActionCmdResultList pcActionCmdResults);

    /// <summary>获取组播状态</summary>
    /// <param name="pcDevInfo">设备信息</param>
    /// <param name="pbStatus">组播状态,true:组播状态，false:非组播</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GIGE_GetMulticastStatus(ref CCameraInfo pcDevInfo, ref bool pbStatus);
  }
}
