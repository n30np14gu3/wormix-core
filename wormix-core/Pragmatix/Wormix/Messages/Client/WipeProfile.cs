using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct WipeProfile : ISerializable
{
    public string ConfirmCode;
    public uint GetSize()
    {
        return (uint)(2 + ConfirmCode.Length);
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}