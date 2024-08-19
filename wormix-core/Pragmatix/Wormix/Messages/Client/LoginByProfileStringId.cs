namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct LoginByProfileStringId
{
    public uint Id;
    public string AuthKey;
    public object[] Ids;
    public uint SocialCode;
}