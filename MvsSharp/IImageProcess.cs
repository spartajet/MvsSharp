// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.IImageProcess
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Drawing;
using MvsSharp.CameraParams;

namespace MvsSharp
{
  /// <summary>图像处理相关接口</summary>
  public interface IImageProcess
  {
    /// <summary>保存图片，支持Bmp和Jpeg</summary>
    /// <param name="pcSaveParam">保存图片参数信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SaveImageEx(ref CSaveImageParam pcSaveParam);

    /// <summary>保存图像到文件</summary>
    /// <param name="pcSaveFileParam">保存图片文件参数信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SaveImageToFile(ref CSaveImgToFileParam pcSaveFileParam);

    /// <summary>保存3D点云数据，支持PLY、CSV和OBJ三种格式</summary>
    /// <param name="pcPointDataParam">保存点云数据参数信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SavePointCloudData(ref CSavePointCloudParam pcPointDataParam);

    /// <summary>图像旋转</summary>
    /// <param name="pcRotateParam">图像旋转参数信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int RotateImage(ref CRotateImageParam pcRotateParam);

    /// <summary>图像翻转</summary>
    /// <param name="pcFlipParam">图像翻转参数信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int FlipImage(ref CFlipImageParam pcFlipParam);

    /// <summary>像素格式转换</summary>
    /// <param name="pcCvtParam">像素格式转换参数信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int ConvertPixelType(ref CPixelConvertParam pcCvtParam);

    /// <summary>像素格式转换(用于GetOneFrameTimeout接口对应)</summary>
    /// <param name="byteSrcData">源图像数据</param>
    /// <param name="pcFrameEx">源图像数据信息</param>
    /// <param name="byteDstData">目标图像数据缓存</param>
    /// <param name="nDataSize">目标图像数据缓存大小</param>
    /// <param name="enDstPixelType">目标图像数据格式</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int ConvertPixelType(
      byte[] byteSrcData,
      ref CFrameoutEx pcFrameEx,
      byte[] byteDstData,
      uint nDataSize,
      MvGvspPixelType enDstPixelType);

    /// <summary>设置插值算法类型</summary>
    /// <param name="nBayerCvtQuality">Bayer的插值方法  0-快速 1-均衡 2-最优（默认为最优）</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetBayerCvtQuality(uint nBayerCvtQuality);

    /// <summary>设置Bayer格式的Gamma值</summary>
    /// <param name="fBayerGammaValue">Gamma值[0.1,4.0]</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetBayerGammaValue(float fBayerGammaValue);

    /// <summary>设置Mono8/Bayer8/10/12/16格式的Gamma值</summary>
    /// <param name="enSrcPixelType">像素格式,支持PixelType_Gvsp_Mono8,Bayer8/10/12/16</param>
    /// <param name="fGammaValue">Gamma值[0.1,4.0]</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetGammaValue(MvGvspPixelType enSrcPixelType, float fGammaValue);

    /// <summary>设置Bayer格式的Gamma信息</summary>
    /// <param name="pcGammaParam">Gamma信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetBayerGammaParam(ref CGammaParam pcGammaParam);

    /// <summary>设置Bayer格式的CCM使能和矩阵，量化系数默认1024</summary>
    /// <param name="pcCCMParam">CCM参数</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetBayerCCMParam(ref CCCMParam pcCCMParam);

    /// <summary>设置Bayer格式的CCM使能和矩阵</summary>
    /// <param name="pcCCMParam">CCM参数</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetBayerCCMParamEx(ref CCCMParamEx pcCCMParam);

    /// <summary>插值算法平滑使能设置</summary>
    /// <param name="bFilterEnable">平滑使能</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetBayerFilterEnable(bool bFilterEnable);

    /// <summary>图像对比度调节</summary>
    /// <param name="pcContrastParam">对比度调节参数</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int ImageContrast(ref CContrastParam pcContrastParam);

    /// <summary>无损解码</summary>
    /// <param name="pcDecodeParam">无损解码参数信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int HB_Decode(ref CDecodeParam pcDecodeParam);

    /// <summary>开始录像</summary>
    /// <param name="pcRecordParam">录像参数信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int StartRecord(ref CRecordParam pcRecordParam);

    /// <summary>输入录像数据</summary>
    /// <param name="pcInputFrameInfo">录像数据信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int InputOneFrame(ref CInputFrameInfo pcInputFrameInfo);

    /// <summary>停止录像</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int StopRecord();

    /// <summary>在图像上绘制矩形框辅助线</summary>
    /// <param name="pcRectArea">矩形辅助线的信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int DrawRect(ref CRectArea pcRectArea);

    /// <summary>在图像上绘制圆形辅助线</summary>
    /// <param name="pcCircleArea">圆形辅助线的信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int DrawCircle(ref CCircleArea pcCircleArea);

    /// <summary>在图像上绘制线条</summary>
    /// <param name="pcLinesArea">线条辅助线信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int DrawLines(ref CLinesArea pcLinesArea);

    /// <summary>重构图像(用于分时曝光功能)</summary>
    /// <param name="pcReconstructParam">重构图像参数</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int ReconstructImage(ref CReconstructImageParam pcReconstructParam);

    /// <summary>图像裸数据转为Bitmap图像数据</summary>
    /// <param name="pData">裸图数据</param>
    /// <param name="pFrameInfo">图像信息</param>
    /// <returns>成功, 返回Bitmap对象, 失败， 返回null</returns>
    Bitmap ImageToBitmap(IntPtr pData, ref MV_FRAME_OUT_INFO_EX pFrameInfo);

    /// <summary>图像裸数据转为Bitmap图像数据(超时机制获取一帧图像)</summary>
    /// <param name="pData">裸图数据缓存</param>
    /// <param name="pcFrameEx">图像信息</param>
    /// <returns>成功, 返回Bitmap对象, 失败， 返回null</returns>
    Bitmap ImageToBitmap(byte[] pData, ref CFrameoutEx pcFrameEx);

    /// <summary>图像裸数据转为Bitmap图像数据(内部缓存获取一帧图像)</summary>
    /// <param name="pcFrame">图像数据</param>
    /// <returns></returns>
    Bitmap ImageToBitmap(ref CFrameout pcFrame);
  }
}
