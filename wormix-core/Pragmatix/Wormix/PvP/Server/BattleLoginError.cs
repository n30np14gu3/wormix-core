namespace wormix_core.Pragmatix.Wormix.PvP.Server;

public struct BattleLoginError
{
    public const int MaintenanceWork = 0;
    public const int IncorrectKey = 1;
    public const int AlreadyInGame = 2;
    public const int InternalServerError = 3;

    public int Code;
}