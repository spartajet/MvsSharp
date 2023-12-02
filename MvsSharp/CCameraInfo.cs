// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CCameraInfo
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>相机信息</summary>
  public class CCameraInfo
  {
    /// <summary>版本号高位</summary>
    public ushort nMajorVer;
    /// <summary>版本号低位</summary>
    public ushort nMinorVer;
    /// <summary>MAC地址高位</summary>
    public uint nMacAddrHigh;
    /// <summary>MAC地址低位</summary>
    public uint nMacAddrLow;
    /// <summary>相机类型</summary>
    public uint nTLayerType;

    /// <summary>判断字符编码</summary>
    /// <param name="inputStream"></param>
    /// <returns></returns>
    public bool IsTextUTF8(byte[] inputStream)
    {
      int num1 = 0;
      bool flag = true;
      for (int index = 0; index < inputStream.Length; ++index)
      {
        byte num2 = inputStream[index];
        if (((int) num2 & 128) == 128)
          flag = false;
        if (num1 == 0)
        {
          if (((int) num2 & 128) != 0)
          {
            if (((int) num2 & 192) != 192)
              return false;
            num1 = 1;
            byte num3 = (byte) ((uint) num2 << 2);
            while (((int) num3 & 128) == 128)
            {
              num3 <<= 1;
              ++num1;
            }
          }
        }
        else
        {
          if (((int) num2 & 192) != 128)
            return false;
          --num1;
        }
      }
      return num1 == 0 && !flag;
    }
  }
}
