using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct EnterAccount
{
    public UserProfileStructure UserProfileStructure;
    public List<UserProfileStructure> UserProfileStructures;
    public DailyBonusStructure DailyBonusStructure;
    public int OnlineFriends;
    public int Friends;
    public string SessionKey;
    public bool IsBonusDay;
    public BonusDaysStructure BonusDaysStructure;
    public int AvailableSearchKeys;
    public List<int> Reagents;
    public bool IsSecure;
}