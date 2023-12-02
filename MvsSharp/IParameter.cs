// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.IParameter
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>相机参数配置模块</summary>
  public interface IParameter
  {
    /// <summary>获取设备属性树XML</summary>
    /// <param name="pData">XML数据接收缓存</param>
    /// <param name="nDataSize">接收缓存大小</param>
    /// <param name="pnDataLen">实际数据大小</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int XML_GetGenICamXML(IntPtr pData, uint nDataSize, ref uint pnDataLen);

    /// <summary>获得当前节点的访问模式</summary>
    /// <param name="pstrName">节点名称</param>
    /// <param name="pAccessMode">节点的访问模式</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int XML_GetNodeAccessMode(string pstrName, ref MV_XML_AccessMode pAccessMode);

    /// <summary>获得当前节点的类型</summary>
    /// <param name="pstrName">节点名称</param>
    /// <param name="pInterfaceType">节点的类型</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int XML_GetNodeInterfaceType(string pstrName, ref MV_XML_InterfaceType pInterfaceType);

    /// <summary>获取Integer属性值</summary>
    /// <param name="strKey">属性键值，如获取宽度信息则为"Width"</param>
    /// <param name="pcValue">返回给调用者有关设备属性信息</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GetIntValue(string strKey, ref CIntValue pcValue);

    /// <summary>设置Integer型属性值</summary>
    /// <param name="strKey">属性键值，如获取宽度信息则为"Width"</param>
    /// <param name="nValue">想要设置的设备的属性值</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int SetIntValue(string strKey, long nValue);

    /// <summary>获取Enum属性值</summary>
    /// <param name="strKey">属性键值，如获取像素格式信息则为"PixelFormat"</param>
    /// <param name="pcValue">返回给调用者有关设备属性信息</param>
    /// <returns>成功,返回MV_OK,失败,返回错误码</returns>
    int GetEnumValue(string strKey, ref CEnumValue pcValue);

    /// <summary>获取指定枚举型节点的指定枚举值所对应的字符串名称</summary>
    /// <param name="strKey">键值</param>
    /// <param name="pcEnumEntry">枚举型节点指定枚举值信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetEnumEntrySymbolic(string strKey, ref CEnumEntry pcEnumEntry);

    /// <summary>设置Enum型属性值</summary>
    /// <param name="strKey">属性键值，如获取像素格式信息则为"PixelFormat"</param>
    /// <param name="nValue">想要设置的设备的属性值</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetEnumValue(string strKey, uint nValue);

    /// <summary>设置Enum型属性值</summary>
    /// <param name="strKey">属性键值，如获取像素格式信息则为"PixelFormat"</param>
    /// <param name="strValue">想要设置的设备的属性字符串</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetEnumValueByString(string strKey, string strValue);

    /// <summary>获取Float属性值</summary>
    /// <param name="strKey">属性键值</param>
    /// <param name="pcValue">返回给调用者有关设备属性信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetFloatValue(string strKey, ref CFloatValue pcValue);

    /// <summary>获取Float属性值</summary>
    /// <param name="strKey">属性键值</param>
    /// <param name="fValue">想要设置的设备的属性值</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetFloatValue(string strKey, float fValue);

    /// <summary>获取Boolean属性值</summary>
    /// <param name="strKey">属性键值</param>
    /// <param name="pbValue">返回给调用者有关设备属性值</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetBoolValue(string strKey, ref bool pbValue);

    /// <summary>设置Boolean属性值</summary>
    /// <param name="strKey">属性键值</param>
    /// <param name="bValue">想要设置的设备的属性值</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetBoolValue(string strKey, bool bValue);

    /// <summary>获取String属性值</summary>
    /// <param name="strKey">属性键值</param>
    /// <param name="pcValue">返回给调用者有关设备属性值</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetStringValue(string strKey, ref CStringValue pcValue);

    /// <summary>设置String属性值</summary>
    /// <param name="strKey">属性键值</param>
    /// <param name="strValue">想要设置的设备的属性值</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetStringValue(string strKey, string strValue);

    /// <summary>设置Command型属性值</summary>
    /// <param name="strKey">属性键值</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int SetCommandValue(string strKey);

    /// <summary>清除GenICam节点缓存</summary>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int InvalidateNodes();

    /// <summary>保存设备属性</summary>
    /// <param name="strFileName">属性文件名</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int FeatureSave(string strFileName);

    /// <summary>导入设备属性</summary>
    /// <param name="strFileName">属性文件名</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int FeatureLoad(string strFileName);

    /// <summary>从设备读取文件</summary>
    /// <param name="pcFileAccess">文件存取信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int FileAccessRead(ref CFileAccess pcFileAccess);

    /// <summary>从设备读取文件到本地缓存</summary>
    /// <param name="pcFileAccessEx">文件数据信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int FileAccessReadEx(ref CFileAccessEx pcFileAccessEx);

    /// <summary>将文件写入设备</summary>
    /// <param name="pcFileAccess">文件存取信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int FileAccessWrite(ref CFileAccess pcFileAccess);

    /// <summary>将文件缓存写入设备</summary>
    /// <param name="pcFileAccessEx">文件数据信息</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int FileAccessWriteEx(ref CFileAccessEx pcFileAccessEx);

    /// <summary>获取文件存取的进度</summary>
    /// <param name="pcFileAccessProgress">进度内容</param>
    /// <returns>成功，返回MV_OK；错误，返回错误码</returns>
    int GetFileAccessProgress(ref CFileAccessProgress pcFileAccessProgress);
  }
}
