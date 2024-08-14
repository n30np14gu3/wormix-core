using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class PumpReactionRateResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10032;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is PumpReactionTheHouseResult)
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