namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ChatMessageResponse
{
    public const int Success = 0;
    public const int FriendNotFound = 1;
    public const int FriendIsOffline = 2;

    public int Result;
}