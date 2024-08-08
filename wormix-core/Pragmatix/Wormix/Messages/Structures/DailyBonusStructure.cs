using wormix_core.Extensions;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct DailyBonusStructure : IMessage
{
    public int LoginSequence;
    public int DailyBonusType;
    public int DailyBonusCount;
    public uint GetSize()
    {
        return 
            4 //LoginSequence
            + 4 //DailyBonusType
            + 4; //DailyBonusCount
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)LoginSequence);
        bw.WriteUInt32Be((uint)DailyBonusType);
        bw.WriteUInt32Be((uint)DailyBonusCount);
    }
}