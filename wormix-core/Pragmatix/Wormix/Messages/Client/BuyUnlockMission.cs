using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyUnlockMission(short missionId = -1) : ISerializable 
{
    public short MissionId = missionId;
    public uint GetSize()
    {
        return 2;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}