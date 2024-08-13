using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class PingBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 16;
    }

    public void SerializeCommand(object command, Stream output)
    {
        //Not needed
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return new Ping();
    }
}