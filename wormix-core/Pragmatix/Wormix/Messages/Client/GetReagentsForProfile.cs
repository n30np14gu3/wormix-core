namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct GetReagentsForProfile(uint profileId = 0)
{
    public uint ProfileId = profileId;
}