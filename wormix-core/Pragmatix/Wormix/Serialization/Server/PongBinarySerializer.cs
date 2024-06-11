using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class PongBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10017;
    }

    public void SerializeCommand(object command, Stream output)
    {
        //Not needed Pong cmd
        BinaryCommandHeader header = new BinaryCommandHeader();
        header.SetLength(0);
        header.SetCommandId(GetCommandId());
        header.Write(output);
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        throw new NotImplementedException();
    }
}