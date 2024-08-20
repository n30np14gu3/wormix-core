namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public struct BattleOfferResult
{
    public const int Agree = 0;
    public const int Disagree = 1;
    public const int Busy = 2;

    public int Result;
    
    public uint EnemyId;
    public uint BattleId;
    
}