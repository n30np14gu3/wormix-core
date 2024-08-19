using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct WhoPumpedReactionResult() : ISerializable
{
    public List<ProfileDoubleKeyStructure> TodayPumped = new();
    public List<ProfileDoubleKeyStructure> YesterdayPumped = new();
    public List<ProfileDoubleKeyStructure> TwoDaysAgoPumped = new();
    
    public uint GetSize()
    {
        return (uint)(
            2 + TodayPumped.Sum((x) => x.GetSize() + 2) //TodayPumped[]
            + 2 + YesterdayPumped.Sum((x) => x.GetSize() + 2) //YesterdayPumped[]
            + 2 + TwoDaysAgoPumped.Sum((x) => x.GetSize() + 2) //TwoDaysAgoPumped[]
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        
        bw.WriteUInt16Be((ushort)TodayPumped.Count);
        TodayPumped.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
        
        bw.WriteUInt16Be((ushort)YesterdayPumped.Count);
        YesterdayPumped.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
        
        bw.WriteUInt16Be((ushort)TwoDaysAgoPumped.Count);
        TwoDaysAgoPumped.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
    }
}