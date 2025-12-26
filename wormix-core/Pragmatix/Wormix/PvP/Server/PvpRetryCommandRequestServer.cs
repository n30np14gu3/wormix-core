namespace wormix_core.Pragmatix.Wormix.PvP.Server;

public struct PvpRetryCommandRequestServer()
{
    public uint BattleId;

    public List<object> CommandNums = new();
    public uint TurnNum;
}