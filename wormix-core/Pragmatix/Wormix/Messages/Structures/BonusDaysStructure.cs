using wormix_core.Extensions;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct BonusDaysStructure() : IMessage
{
    public int Money;
    public int RealMoney;
    public int BattlesCount;
    public string BonusMessage = "";
    
    public uint GetSize()
    {
        return 
            (uint)(
                4 
                + 4
                + 4 
                + 2 + BonusMessage.Length
            );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        
        bw.WriteUInt32Be((uint)Money);
        bw.WriteUInt32Be((uint)RealMoney);
        bw.WriteUInt32Be((uint)BattlesCount);
        bw.WriteUTF8(BonusMessage);
    }
}