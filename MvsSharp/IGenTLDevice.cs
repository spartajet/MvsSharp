// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.IGenTLDevice
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>GenTL相关接口</summary>
  public interface IGenTLDevice : IDevice
  {
    /// <summary>卸载cti库</summary>
    /// <param name="strGenTLPath">枚举卡时加载的cti文件路径</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int UnloadGenTLLibrary(string strGenTLPath);

    /// <summary>通过GenTL设备信息创建设备句柄</summary>
    /// <param name="pcDevInfo">设备信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int CreateHandleByGenTL(ref CGenTLDevInfo pcDevInfo);
  }
}
