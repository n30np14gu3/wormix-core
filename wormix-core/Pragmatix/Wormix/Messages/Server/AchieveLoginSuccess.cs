namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct AchieveLoginSuccess
{
    public string SessionId;
    public uint LoginTime;
    public bool IsSecure;
}