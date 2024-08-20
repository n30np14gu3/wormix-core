namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public struct BattleRequest()
{
    public string Host;
    public int Port;
    public uint MapId;
    public int Seed;
    public string EnemyId = "";
}