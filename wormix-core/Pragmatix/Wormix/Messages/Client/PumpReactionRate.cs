using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct PumpReactionRate : ISerializable
{
    public uint FriendId;
    
    public uint GetSize()
    {
        return 4;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}