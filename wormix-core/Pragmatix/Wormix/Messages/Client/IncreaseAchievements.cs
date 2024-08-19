namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct IncreaseAchievements
{
    public string SessionId;
    public object[] AchievementsIndex;
    public object[] AchievementsRise;
    public uint TimeScale;
    public bool IsSecure;
}