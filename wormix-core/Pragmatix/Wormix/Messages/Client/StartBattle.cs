using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct StartBattle : ISerializable
{
    public int MissionId;

    public uint GetSize()
    {
        return 4;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}