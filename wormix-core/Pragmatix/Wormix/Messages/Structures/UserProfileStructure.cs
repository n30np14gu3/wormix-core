namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct UserProfileStructure()
{
    public uint Id;
    public string SocialId;
    
    public uint Money;
    public uint RealMoney;
    
    public int Rating;

    public List<object> WormsGroup;
    public List<object> WeaponRecordList;
    
    public List<object> Stuff;
    
    public int ReactionRate;
    
    public List<object> Recipes = new();
}