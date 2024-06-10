namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct Ping(uint friendId = 0)
{
    public uint FriendId = friendId;
}