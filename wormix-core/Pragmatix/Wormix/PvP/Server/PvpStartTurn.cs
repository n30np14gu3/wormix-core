namespace wormix_core.Pragmatix.Wormix.PvP.Server;

public struct PvpStartTurn()
{
    public uint BattleId;
    public uint ProfileId;
    
    public uint TurnNum;
    public uint CommandNum;
    
    public List<object> DroppedIds = new();
}