namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetAchievementsResult
{
    public string ProfileId;
    public List<object> AchievementsIndex;
    public List<object> Achievements;
    public int InvestedAwardPoints;
    public bool IsSecure;
}