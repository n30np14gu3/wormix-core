using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class ChangeRaceResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10028;
    }

    public void SerializeCommand(object command, Stream output)
    {
        if (command is ChangeRaceResult result)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(result.GetSize());
            
            header.Write(output);
            result.Serialize(output);
        }
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}