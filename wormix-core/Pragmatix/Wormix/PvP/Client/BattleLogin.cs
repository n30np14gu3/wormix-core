using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public struct BattleLogin() : ISerializable
{
    public uint Id;
    public bool FirstTurn;
    
    public string AuthKey = "";
    public List<uint> EnemyIds = new();
    
    public string MainHost = "";
    public int MainPort;

    public uint BattleId;
    
    public byte SocialId;
    
    public uint GetSize()
    {
        return (uint)(
            2 //Id
            + 1 //FirstTurn
            + 2 + AuthKey.Length //AuthKey
            + 2 + EnemyIds.Count * 2 //EnemyIds
            + 2 + MainHost.Length //MainHost
            + 4 //MainPort
            + 4 //BattleId
            + 1 //SocialId
            
        );
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}