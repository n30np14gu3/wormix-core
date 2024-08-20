namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public struct PvpEndBattle()
{
    public const int ResultNormal = 0;
    public const int ResultSurrender = 1;
    public const int ResultOpponentCheater = 2;
    public const int ResultStuck = 3;
    public const int ResultIamCheater = 4;
    public const int ResultDesync = 5;


    public bool Desync;
    public uint BattleId;
    public uint TurnNum;
    public uint CommandId;
    public List<object> Players = new();
    public List<object> Results = new();
    public List<object> Signatures = new();
}