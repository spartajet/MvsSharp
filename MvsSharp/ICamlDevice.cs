// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.ICamlDevice
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>CameraLink独有的接口</summary>
  public interface ICamlDevice : IDevice
  {
    /// <summary>设置设备波特率</summary>
    /// <param name="enBaudrate">设置的波特率值，如MV_CAML_BAUDRATE_9600</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int CAML_SetDeviceBaudrate(MV_CAML_BAUDRATE enBaudrate);

    /// <summary>获取设备波特率</summary>
    /// <param name="penCurrentBaudrate">波特率信息，如MV_CAML_BAUDRATE_9600</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int CAML_GetDeviceBaudrate(ref MV_CAML_BAUDRATE penCurrentBaudrate);

    /// <summary>获取设备与主机间连接支持的波特率</summary>
    /// <param name="penBaudrateAblity">支持的波特率信息，所支持波特率的或运算结果，如MV_CAML_BAUDRATE_9600</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int CAML_GetSupportBaudrates(ref MV_CAML_BAUDRATE penBaudrateAblity);

    /// <summary>设置串口操作等待时长</summary>
    /// <param name="nMillisec">串口操作的等待时长, 单位为ms</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int CAML_SetGenCPTimeOut(uint nMillisec);
  }
}
