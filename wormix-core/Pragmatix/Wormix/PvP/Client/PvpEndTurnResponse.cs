namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public class PvpEndTurnResponse : PvpCommand
{
    public List<object> Eliminated = new();
    public int BattleState;
}