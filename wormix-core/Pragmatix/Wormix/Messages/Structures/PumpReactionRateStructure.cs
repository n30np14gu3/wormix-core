using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct PumpReactionRateStructure : ISerializable
{
    public uint FriendId;
    public byte Result;
    
    public uint GetSize()
    {
        return 5;// 4: FriendId, 1 - Result
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(FriendId);
        bw.Write(Result);
    }
}