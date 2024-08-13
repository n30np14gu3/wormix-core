namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct Pong : IMessage
{
    public uint GetSize()
    {
        return 0;
    }

    public void Serialize(Stream output)
    {
        //Message is null
    }
}