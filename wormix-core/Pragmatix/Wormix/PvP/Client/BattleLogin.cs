namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public struct BattleLogin()
{
    public uint Id;
    public bool FirstTurn;
    
    public string AuthKey = "";
    public List<uint> EnemyIds = new();
    
    public string MainHost = "";
    public int MainPort;

    public uint BattleId;
    
    public uint SocialId;
}