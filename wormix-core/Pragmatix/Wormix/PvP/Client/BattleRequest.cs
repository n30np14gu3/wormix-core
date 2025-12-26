using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.PvP.Client;

public struct BattleRequest() : ISerializable
{
    public string Host;
    public int Port;
    
    public uint MapId;
    
    public int Seed;
    
    public string EnemyId = "";
    
    public uint GetSize()
    {
        //Not needed
        return 0;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}