using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.PvP.Wager;

public struct WagerBattleRequestResult()
{
    public string Host = "";
    public int Port;

    public uint MapId;

    public UserProfileStructure EnemyProfile = new();
    public UserProfileStructure UserProfile = new();

    public uint FirstPlayerId;

    public int Seed;

    public uint BattleId;

    public List<int> ReagentsForBattle;
}