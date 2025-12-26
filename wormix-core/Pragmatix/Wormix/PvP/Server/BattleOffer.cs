using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.PvP.Server;

public struct BattleOffer()
{
    public string Host = "";
    public int Port;
    
    public uint MapId;
    public int Seed;
    
    public UserProfileStructure EnemyProfile = new();
    public UserProfileStructure MyProfile = new();
    
    public uint BattleId;
}