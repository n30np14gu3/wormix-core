using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class ResetParametersResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10016;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is ResetParametersResult result)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(result.GetSize());
            header.Write(output);
            result.Serialize(output);
        }
        else
            throw new InvalidCastException("Invalid ResetParametersResult struct");
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}