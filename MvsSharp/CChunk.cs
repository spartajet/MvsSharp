// Decompiled with JetBrains decompiler
// Type: MvCamCtrl.NET.CChunk
// Assembly: MvCamCtrl.Net, Version=4.1.0.3, Culture=neutral, PublicKeyToken=52fddfb3f94be800
// MVID: 48858B75-944A-430D-BA88-8043A97023D9
// Assembly location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.dll
// XML documentation location: C:\Program Files (x86)\MVS\Development\DotNet\win64\MvCamCtrl.Net.xml

namespace MvsSharp
{
  /// <summary>Chunk类</summary>
  public class CChunk
  {
    /// <summary>Chunk宽度</summary>
    public ushort ChunkWidth { get; set; }

    /// <summary>Chunk高度</summary>
    public ushort ChunkHeight { get; set; }

    /// <summary>未解析的Chunk数</summary>
    public uint UnparsedChunkNum { get; set; }

    /// <summary>Chunk内容</summary>
    public CChunkDataContent ChunkDataContent { get; set; }

    /// <summary>构造函数</summary>
    public CChunk() => this.ChunkDataContent = new CChunkDataContent();
  }
}
