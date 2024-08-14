using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetWhoPumpedReactionBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 46;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        GetWhoPumpedReaction result = new();
        BinaryReader br = new BinaryReader(input);
        result.TodayOnly = br.ReadBoolean();

        return result;
    }
}