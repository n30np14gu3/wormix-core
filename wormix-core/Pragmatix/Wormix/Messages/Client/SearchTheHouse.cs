using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SearchTheHouse(string sessionKey = "", uint friendId = 0, byte keyNum = 0) : ISerializable
{
    public string SessionKey = sessionKey;
    public uint FriendId = friendId;
    public byte KeyNum = keyNum;
    
    public uint GetSize()
    {
        return (uint)(
            2 + SessionKey.Length //SessionKey
            + 4 //FriendID
            + 1 //KeyNum
            );
    }

    public void Serialize(Stream output)
    {
        throw new NotImplementedException();
    }
}