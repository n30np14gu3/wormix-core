using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.PvP.Server;

public struct BattleRequestResult()
{
    public const int Agree = 0;
    public const int Disagree = 1;
    public const int Busy = 2;
    public const int EnemyIdNotFound = 3;
    public const int NotOnline = 4;

    public int Result;
    
    
    public UserProfileStructure EnemyProfile = new();
    public UserProfileStructure MyProfile = new();
    
    public uint BattleId;
}