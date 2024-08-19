using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct Ping(uint friendId = 0) : ISerializable
{
    public uint FriendId = friendId;
    public uint GetSize()
    {
        return 0;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}