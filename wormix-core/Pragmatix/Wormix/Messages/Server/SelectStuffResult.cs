using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SelectStuffResult : ISerializable
{
    public const int Success = 0;
    public const int Error = 1;

    public short Result;
    public short StuffId;
    
    public bool IsSecure;

    public uint GetSize()
    {
        return 2 //Result
               + 2; //StuffId
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt16Be((ushort)StuffId);
    }
}