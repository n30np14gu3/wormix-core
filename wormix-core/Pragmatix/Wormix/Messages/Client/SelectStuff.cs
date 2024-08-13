namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SelectStuff(short stuffId = 0) : IMessage
{
    public short StuffId = stuffId;
    public uint GetSize()
    {
        return 2;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}