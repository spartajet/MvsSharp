// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.IStreamGrabber
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>相机取图模块</summary>
  public interface IStreamGrabber
  {
    /// <summary>注册图像数据回调</summary>
    /// <param name="cbOutput">图像数据回调代理</param>
    /// <param name="pUser">用户自定义变量</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int RegisterImageCallBackEx(cbOutputExdelegate cbOutput, IntPtr pUser);

    /// <summary>注册图像数据回调，RGB</summary>
    /// <param name="cbOutput">图像数据回调代理</param>
    /// <param name="pUser">用户自定义变量</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int RegisterImageCallBackForRGB(cbOutputExdelegate cbOutput, IntPtr pUser);

    /// <summary>注册图像数据回调，BGR</summary>
    /// <param name="cbOutput">图像数据回调代理</param>
    /// <param name="pUser">用户自定义变量</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int RegisterImageCallBackForBGR(cbOutputExdelegate cbOutput, IntPtr pUser);

    /// <summary>开始取流</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int StartGrabbing();

    /// <summary>停止取流</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int StopGrabbing();

    /// <summary>
    /// 获取一帧RGB数据，此函数为查询式获取，每次调用查询内部
    /// 缓存有无数据，有数据则获取数据，无数据返回错误码
    /// </summary>
    /// <param name="pData">图像缓存</param>
    /// <param name="nDataSize">图像缓存大小</param>
    /// <param name="pcFrameEx">图像信息结构体</param>
    /// <param name="nMsec">等待超时时间</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetImageForRGB(byte[] pData, uint nDataSize, ref CFrameoutEx pcFrameEx, int nMsec);

    /// <summary>
    /// 获取一帧BGR数据，此函数为查询式获取，每次调用查询内部
    /// 缓存有无数据，有数据则获取数据，无数据返回错误码
    /// </summary>
    /// <param name="pData">图像缓存</param>
    /// <param name="nDataSize">图像缓存大小</param>
    /// <param name="pcFrameEx">图像信息结构体</param>
    /// <param name="nMsec">等待超时时间</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetImageForBGR(byte[] pData, uint nDataSize, ref CFrameoutEx pcFrameEx, int nMsec);

    /// <summary>使用内部缓存获取一帧图片</summary>
    /// <param name="pcFrame">图像数据和图像信息</param>
    /// <param name="nMsec">等待超时时间，输入INFINITE时表示无限等待，直到收到一帧数据或者停止取流</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetImageBuffer(ref CFrameout pcFrame, int nMsec);

    /// <summary>释放图像缓存(此接口用于释放不再使用的图像缓存，与GetImageBuffer配套使用)</summary>
    /// <param name="pcFrame">图像数据和图像信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int FreeImageBuffer(ref CFrameout pcFrame);

    /// <summary>采用超时机制获取一帧图片，SDK内部等待直到有数据时返回</summary>
    /// <param name="pData">图像缓存</param>
    /// <param name="nDataSize">图像缓存大小</param>
    /// <param name="pcFrameEx">图像信息结构体</param>
    /// <param name="nMsec">等待超时时间</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetOneFrameTimeout(byte[] pData, uint nDataSize, ref CFrameoutEx pcFrameEx, int nMsec);

    /// <summary>清除取流数据缓存</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int ClearImageBuffer();

    /// <summary>显示一帧图像</summary>
    /// <param name="pcDisplayInfo">图像信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int DisplayOneFrame(ref CDisplayFrameInfo pcDisplayInfo);

    /// <summary>显示一帧图像(扩展图像的高宽)</summary>
    /// <param name="pcDisplayInfoEx">图像信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int DisplayOneFrameEx(ref CDisplayFrameInfoEx pcDisplayInfoEx);

    /// <summary>设置SDK内部图像缓存节点个数，大于等于1，在抓图前调用</summary>
    /// <param name="nNum">缓存节点个数</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetImageNodeNum(uint nNum);

    /// <summary>设置取流策略</summary>
    /// <param name="enGrabStrategy">策略枚举值</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetGrabStrategy(MV_GRAB_STRATEGY enGrabStrategy);

    /// <summary>
    /// 设置输出缓存个数（只有在MV_GrabStrategy_LatestImages策略下才有效，范围：1-ImageNodeNum）
    /// </summary>
    /// <param name="nOutputQueueSize">输出缓存个数</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetOutputQueueSize(uint nOutputQueueSize);
  }
}
