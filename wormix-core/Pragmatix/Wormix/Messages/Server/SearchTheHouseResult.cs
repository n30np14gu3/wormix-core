using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SearchTheHouseResult : ISerializable
{
    public const byte Empty = 0;
    public const byte RealMoney = 1;
    public const byte Money = 2;
    public const byte Error = 3;
    public const byte NoFiveDay = 4;
    public const byte KeyLimitExceed = 5;
    public const byte Reagent = 7;

    public byte Result;
    public int Value;
    public byte AvailableSearchKeys;
    public uint FriendId;
    public bool IsSecure;
    public uint GetSize()
    {
        return
            1 //Result
            + 4 //Value
            + 1 //AvailableSearchKeys
            + 4; //FriendId
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write(Result);
        bw.WriteUInt32Be((uint)Value);
        bw.Write(AvailableSearchKeys);
        bw.WriteUInt32Be(FriendId);
    }
}