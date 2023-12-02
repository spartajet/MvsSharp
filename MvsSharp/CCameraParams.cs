// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CCameraParams
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>相机参数</summary>
  public class CCameraParams
  {
    /// <summary>
    /// ch:信息结构体的最大缓存 | en: Max buffer size of information structs
    /// </summary>
    public const int INFO_MAX_BUFFER_SIZE = 64;
    /// <summary>最大的相机数量</summary>
    public const int MV_MAX_DEVICE_NUM = 256;
    /// <summary>ch:最大Interface数量 | en:Max num of interfaces</summary>
    public const int MV_MAX_GENTL_IF_NUM = 256;
    /// <summary>ch:最大GenTL设备数量 | en:Max num of GenTL devices</summary>
    public const int MV_MAX_GENTL_DEV_NUM = 256;
    /// <summary>XML节点描述最大长度</summary>
    public const int MV_MAX_XML_DISC_STRLEN_C = 512;
    /// <summary>XML节点最大长度</summary>
    public const int MV_MAX_XML_NODE_STRLEN_C = 64;
    /// <summary>XML节点最大数量</summary>
    public const int MV_MAX_XML_NODE_NUM_C = 128;
    /// <summary>XML节点显示名最大数量</summary>
    public const int MV_MAX_XML_SYMBOLIC_NUM = 64;
    /// <summary>string类型节点值的最大长度</summary>
    public const int MV_MAX_XML_STRVALUE_STRLEN_C = 64;
    /// <summary>最大父节点数</summary>
    public const int MV_MAX_XML_PARENTS_NUM = 8;
    /// <summary>最大节点描述长度</summary>
    public const int MV_MAX_XML_SYMBOLIC_STRLEN_C = 64;
    /// <summary>设备断开连接</summary>
    public const int MV_EXCEPTION_DEV_DISCONNECT = 32769;
    /// <summary>SDK与驱动版本不匹配</summary>
    public const int MV_EXCEPTION_VERSION_CHECK = 32770;
    /// <summary>相机Event事件名称最大长度</summary>
    public const int MAX_EVENT_NAME_SIZE = 128;
    /// <summary>最大枚举条目对应的符号长度</summary>
    public const int MV_MAX_SYMBOLIC_LEN = 64;
    /// <summary>分时曝光时最多将源图像拆分的个数</summary>
    public const int MV_MAX_SPLIT_NUM = 8;
  }
}
