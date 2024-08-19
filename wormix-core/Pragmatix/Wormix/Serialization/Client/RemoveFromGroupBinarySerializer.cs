using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class RemoveFromGroupBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 13;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        RemoveFromGroup result = new();
        BinaryReader br = new BinaryReader(input);
        result.ProfileId = br.ReadUInt32Be();
        return result;
    }
}