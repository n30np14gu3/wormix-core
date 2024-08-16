using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct NeedMoneyResult : ISerializable
{
    public const int Success = 0;
    public const int Error = 1;
    public const int NotEnoughMoney = 3;

    public int Value;
    public short Result;

    public uint GetSize()
    {
        return
            4 //Value
            + 2; //Result
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Value);
        bw.WriteUInt16Be((ushort)Result);
    }
}