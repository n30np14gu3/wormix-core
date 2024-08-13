using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class ArenaResultBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10004;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is ArenaResult arenaResult)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            
            header.SetCommandId(GetCommandId());
            header.SetLength(arenaResult.GetSize());
            header.Write(output);
            
            arenaResult.Serialize(output);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}