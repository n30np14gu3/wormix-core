namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public class PvpEndTurn : PvpCommand
{
    public List<object> Eliminated = new();
    public int BattleState;
}