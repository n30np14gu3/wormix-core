namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyUnlockMission(int missionId = -1)
{
    public int MissionId = missionId;
}