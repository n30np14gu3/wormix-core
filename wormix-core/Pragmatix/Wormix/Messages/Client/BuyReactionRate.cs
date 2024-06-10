namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyReactionRate(uint reactionRateCount = 0)
{
    public uint ReactionRateCount = reactionRateCount;
}