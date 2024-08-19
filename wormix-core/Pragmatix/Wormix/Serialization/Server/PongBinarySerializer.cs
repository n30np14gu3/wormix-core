using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class PongBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10017;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed Pong cmd
        BinaryCommandHeader header = new BinaryCommandHeader();
        header.SetLength(0);
        header.SetCommandId(GetCommandId());
        header.Write(output);
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}