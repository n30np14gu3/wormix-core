namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct StartBattleResult()
{
    public List<object> Awards = new();
    public uint BattleId;
    public List<int> ReagentForBattle = new();
}