namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public struct BattleReconnect()
{
    public uint Id;
    public bool FirstTurn;
    
    public string AuthKey = "";
    
    public string MainHost = "";
    public int MainPort;

    public uint BattleId;
    public uint TurnNum;
    public uint PlayerNum;
    public uint LastCommandId;

    public uint SocialId;
}