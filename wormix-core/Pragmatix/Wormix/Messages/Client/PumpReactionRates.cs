using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct PumpReactionRates() : ISerializable
{
    public List<uint> FriendsIds = new();
    
    public uint GetSize()
    {
        return (uint)(FriendsIds.Count * 4);
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}