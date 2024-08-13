using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class ArenaLockedBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 10007;
    }

    public void SerializeCommand(object command, Stream output)
    {
        if (command is ArenaLocked locked)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(locked.GetSize());
            header.Write(output);
            locked.Serialize(output);
        }
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}