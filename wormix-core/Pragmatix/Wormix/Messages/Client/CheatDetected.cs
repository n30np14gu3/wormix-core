namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct CheatDetected
{
    public string SessionKey;
    public uint BanType;
    public string BanNote;
}