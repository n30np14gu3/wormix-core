using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct IncomingPayment : ISerializable
{
    public int MoneyType;
    public int Count;
    public uint GetSize()
    {
        return
            4 //MoneyType
            + 4; //Count
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)MoneyType);
        bw.WriteUInt32Be((uint)Count);
    }
}