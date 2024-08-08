using wormix_core.Extensions;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct UserIsBanned : IMessage
{
    public int Reason;
    public uint EndDate;

    public uint GetSize()
    {
        return
            4 //Reason
            + 4; //EndDate
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Reason);
        bw.WriteUInt32Be(EndDate);
    }
}