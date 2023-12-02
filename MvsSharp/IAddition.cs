// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.IAddition
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>附加模块</summary>
  public interface IAddition
  {
    /// <summary>设备本地升级</summary>
    /// <param name="pFilePathName">文件路径及文件名</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int LocalUpgrade(string pFilePathName);

    /// <summary>获取升级进度</summary>
    /// <param name="pnProcess">进度接收地址</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GetUpgradeProcess(ref uint pnProcess);

    /// <summary>读内存</summary>
    /// <param name="pBuffer">作为返回值使用，保存读到的内存值（GEV设备内存值是按照大端模式存储的，其它协议设备按照小端存储）</param>
    /// <param name="nAddress">待读取的内存地址，该地址可以从设备的Camera.xml文件中获取，形如xxx_RegAddr的xml节点值</param>
    /// <param name="nLength">待读取的内存长度</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int ReadMemory(IntPtr pBuffer, long nAddress, long nLength);

    /// <summary>写内存</summary>
    /// <param name="pBuffer">待写入的内存值（注意GEV设备内存值要按照大端模式存储，其它协议设备按照小端存储）</param>
    /// <param name="nAddress">待写入的内存地址，该地址可以从设备的Camera.xml文件中获取，形如xxx_RegAddr的xml节点值</param>
    /// <param name="nLength">待写入的内存长度</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int WriteMemory(IntPtr pBuffer, long nAddress, long nLength);

    /// <summary>注册异常消息回调，在打开设备之后调用</summary>
    /// <param name="cbException">异常回调代理</param>
    /// <param name="pUser">用户自定义变量</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int RegisterExceptionCallBack(cbExceptiondelegate cbException, IntPtr pUser);

    /// <summary>注册全部事件回调，在打开设备之后调用</summary>
    /// <param name="cbEvent">事件回调代理</param>
    /// <param name="pUser">用户自定义变量</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int RegisterAllEventCallBack(cbEventdelegateEx cbEvent, IntPtr pUser);

    /// <summary>注册单个事件回调，在打开设备之后调用</summary>
    /// <param name="pEventName">事件名称</param>
    /// <param name="cbEvent">事件回调代理</param>
    /// <param name="pUser">用户自定义变量</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int RegisterEventCallBackEx(string pEventName, cbEventdelegateEx cbEvent, IntPtr pUser);

    /// <summary>打开获取或设置相机参数的GUI界面</summary>
    /// <returns>成功，返回MV_OK，失败，返回错误码</returns>
    int OpenParamsGUI();
  }
}
