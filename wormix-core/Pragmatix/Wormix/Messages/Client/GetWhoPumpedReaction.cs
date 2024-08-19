using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct GetWhoPumpedReaction : ISerializable
{
    public bool TodayOnly;
    public uint GetSize()
    {
        return 1;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}