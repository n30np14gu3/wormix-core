using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyReactionRate(byte reactionRateCount = 0) : ISerializable
{
    public byte ReactionRateCount = reactionRateCount;
    
    public uint GetSize()
    {
        return 1;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}