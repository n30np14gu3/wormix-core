namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct RemoveFromGroup(uint profileId = 0)
{
    public uint ProfileId = profileId;
}