// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CChunkDataContent
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

using System.Runtime.InteropServices;

namespace MvsSharp
{
  /// <summary>chunk内容</summary>
  public class CChunkDataContent
  {
    /// <summary>Chunk数据地址</summary>
    public IntPtr ChunkAddr { get; set; }

    /// <summary>Chunk数据</summary>
    public byte[] ChunkData
    {
      get
      {
        if (IntPtr.Zero == this.ChunkAddr)
          return (byte[]) null;
        this.ChunkData = new byte[(int) this.ChunkLen];
        Marshal.Copy(this.ChunkAddr, this.ChunkData, 0, (int) this.ChunkLen);
        return this.ChunkData;
      }
      set
      {
        this.ChunkData = new byte[value.Length];
        this.ChunkData = value;
      }
    }

    /// <summary>ChunkID</summary>
    public uint ChunkID { get; set; }

    /// <summary>Chunk数据长度</summary>
    public uint ChunkLen { get; set; }

    /// <summary>构造函数</summary>
    /// <returns></returns>
    public CChunkDataContent()
    {
      this.ChunkAddr = IntPtr.Zero;
      this.ChunkID = 0U;
      this.ChunkLen = 0U;
    }

    /// <summary>析构函数</summary>
    ~CChunkDataContent()
    {
      if (!(IntPtr.Zero != this.ChunkAddr))
        return;
      this.ChunkAddr = IntPtr.Zero;
    }
  }
}
