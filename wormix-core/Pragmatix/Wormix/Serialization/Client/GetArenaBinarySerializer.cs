using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetArenaBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 4;
    }

    public void SerializeCommand(object command, Stream output)
    {
        throw new NotImplementedException();
    }

    public object DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Very simple xD
        
        BinaryReader br = new BinaryReader(input);
        
        GetArena arena = new GetArena();
        arena.ReturnUsersProfiles = br.ReadBoolean();
        return arena;
    }
}