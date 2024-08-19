using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SendWipeConfirmCode : ISerializable
{
    public int Level;
    public int Experience;
    public int Rating;
    public uint GetSize()
    {
        return 12;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}