// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CTransMissionType
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>传输模式</summary>
  public class CTransMissionType
  {
    /// <summary>传输模式</summary>
    public MV_GIGE_TRANSMISSION_TYPE TransmissionType { get; set; }

    /// <summary>目标IP，组播模式下有意义</summary>
    public uint DestIp { get; set; }

    /// <summary>目标Port，组播模式下有意义</summary>
    public ushort DestPort { get; set; }
  }
}
