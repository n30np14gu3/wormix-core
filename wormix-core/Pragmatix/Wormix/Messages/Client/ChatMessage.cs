namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct ChatMessage
{
    public const int ChangePlayersToFight = 1;

    public uint FromProfileId;
    public uint ToFriendId;
    public string Msg;
    public int PredefinedMsgType;
}