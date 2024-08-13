using wormix_core.Extensions;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ArenaLocked : IMessage
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