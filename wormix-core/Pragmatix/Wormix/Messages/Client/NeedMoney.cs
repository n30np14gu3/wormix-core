using wormix_core.Pragmatix.Flox.Model;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct NeedMoney(int value = 0) : ISerializable
{
    public int Value = value;
    public int MoneyType;


    public uint GetSize()
    {
        return 8;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}