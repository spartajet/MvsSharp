// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.IU3VDevice
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>U3V独有的接口</summary>
  public interface IU3VDevice : IDevice
  {
    /// <summary>设置U3V的传输包大小</summary>
    /// <param name="nTransferSize">传输的包大小, Byte，默认为1M，rang：&gt;=0x10000</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int USB_SetTransferSize(uint nTransferSize);

    /// <summary>获取U3V的传输包大小</summary>
    /// <param name="pnTransferSize">传输的包大小</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int USB_GetTransferSize(ref uint pnTransferSize);

    /// <summary>设置U3V的传输通道个数</summary>
    /// <param name="nTransferWays">传输通道个数，范围：1-10</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int USB_SetTransferWays(uint nTransferWays);

    /// <summary>获取U3V的传输通道个数</summary>
    /// <param name="pnTransferWays">传输通道个数</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int USB_GetTransferWays(ref uint pnTransferWays);

    /// <summary>注册流异常消息回调，在打开设备之后调用（只支持U3V相机）</summary>
    /// <param name="cbException">异常回调函数</param>
    /// <param name="pUser">用户自定义变量</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int USB_RegisterStreamExceptionCallBack(cbStreamExceptiondelegate cbException, IntPtr pUser);

    /// <summary>设置U3V的事件缓存节点个数</summary>
    /// <param name="nEventNodeNum">事件缓存节点个数，范围：1-64</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int USB_SetEventNodeNum(uint nEventNodeNum);

    /// <summary>设置U3V的同步读写超时时间，范围为0 ~ UINT_MAX(最小值包含0，最大值根据操作系统位数决定)</summary>
    /// <param name="nMills">设置同步读写超时时间,默认时间为1000ms(1s)</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int USB_SetSyncTimeOut(uint nMills);

    /// <summary>获取U3V相机同步读写超时时间</summary>
    /// <param name="pnMills">获取的超时时间(ms), 默认1000ms</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int USB_GetSyncTimeOut(ref uint pnMills);
  }
}
