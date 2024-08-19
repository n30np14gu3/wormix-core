using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct Pong : ISerializable
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