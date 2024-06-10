namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SearchTheHouse(string sessionKey = "", uint friendId = 0, int keyNum = 0)
{
    public string SessionKey = sessionKey;
    public uint FriendId = friendId;
    public int KeyNum = keyNum;
}