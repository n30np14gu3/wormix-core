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
}