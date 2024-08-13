using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct AchieveLogin : ISerializable
{
    public string ApplicationId;
    public string SocialNetworkId;
    public string Id;
    public string AuthKey;
    public bool SendAchievements;

    public uint GetSize()
    {
        return
            (uint)(
                SocialNetworkId.Length
                + ApplicationId.Length
                + Id.Length
                + AuthKey.Length
                + 1
                ); //SendAchievements size
    }

    public void Serialize(Stream output)
    {
        //Nothing
    }
}