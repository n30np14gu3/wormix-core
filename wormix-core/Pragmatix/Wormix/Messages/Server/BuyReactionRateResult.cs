using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct BuyReactionRateResult : ISerializable
{
    public short Result;
    public byte ReactionRateCount;
    public uint GetSize()
    {
        return
            2 //Result
            + 1; //ReactionRateCount
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.Write(ReactionRateCount);
    }
}