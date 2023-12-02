// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.IDevice
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>设备的基本指令和操作</summary>
  public interface IDevice
  {
    /// <summary>创建设备句柄</summary>
    /// <param name="pcDevInfo">设备信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int CreateHandle(ref CCameraInfo pcDevInfo);

    /// <summary>创建设备句柄，不生成日志</summary>
    /// <param name="pcDevInfo">设备信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int CreateHandleWithoutLog(ref CCameraInfo pcDevInfo);

    /// <summary>销毁句柄</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int DestroyHandle();

    /// <summary>打开设备</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int OpenDevice();

    /// <summary>打开设备</summary>
    /// <param name="nAccessMode">访问权限</param>
    /// <param name="nSwitchoverKey">切换访问权限时的密钥</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int OpenDevice(uint nAccessMode, ushort nSwitchoverKey);

    /// <summary>关闭设备</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int CloseDevice();

    /// <summary>判断设备是否处于连接状态</summary>
    /// <returns>设备处于连接状态，返回true；没连接或失去连接，返回false</returns>
    bool IsDeviceConnected();

    /// <summary>获取设备信息，取流之前调用</summary>
    /// <param name="pcDevInfo">返回给调用者有关设备信息</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GetDeviceInfo(ref CCameraInfo pcDevInfo);

    /// <summary>获取各种类型的信息</summary>
    /// <param name="pcMatchInfo">返回给调用者有关设备各种类型的信息</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GetAllMatchInfo(ref CAllMatchInfo pcMatchInfo);

    /// <summary>获取当前图像缓存区的有效图像个数</summary>
    /// <param name="pnValidImageNum">当前图像缓存区中有效图像个数</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GetValidImageNum(ref uint pnValidImageNum);
  }
}
