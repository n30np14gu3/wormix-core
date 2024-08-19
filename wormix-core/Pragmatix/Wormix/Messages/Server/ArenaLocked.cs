using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ArenaLocked : ISerializable
{
    public uint Delay;
    public short MissionId;
    public byte ErrorCode;
    
    public uint GetSize()
    {
        return
            4 //Delay
            + 2//MissionId
            + 1; //ErrorCode
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Delay);
        bw.WriteUInt16Be((ushort)MissionId);
        bw.Write(ErrorCode);
    }
}