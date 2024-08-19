using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyReactionRateBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 49;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuyReactionRate result = new();
        BinaryReader br = new BinaryReader(input);
        result.ReactionRateCount = br.ReadByte();
        return result;
    }
}