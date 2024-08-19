using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class ReorderGroupResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 1022;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is ReorderGroupResult)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(command.GetSize());
            header.Write(output);
            command.Serialize(output);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}