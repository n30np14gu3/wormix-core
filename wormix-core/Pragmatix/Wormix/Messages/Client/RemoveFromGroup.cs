using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct RemoveFromGroup(uint profileId = 0) : ISerializable
{
    public uint ProfileId = profileId;
    public uint GetSize()
    {
        return 4;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}