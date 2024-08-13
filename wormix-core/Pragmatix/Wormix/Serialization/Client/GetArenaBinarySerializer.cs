using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetArenaBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 4;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Very simple xD
        BinaryReader br = new BinaryReader(input);
        GetArena arena = new GetArena
        {
            ReturnUsersProfiles = br.ReadBoolean()
        };
        return arena;
    }
}