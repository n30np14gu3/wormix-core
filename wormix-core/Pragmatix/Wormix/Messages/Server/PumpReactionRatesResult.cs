using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct PumpReactionRatesResult() : ISerializable
{
    public List<PumpReactionRateStructure> PumpedFriends = new();

    public uint GetSize()
    {
        return (uint)(
            2 + PumpedFriends.Count * PumpedFriends.Sum(x => x.GetSize() + 2)); //PumpedFriends[]
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)PumpedFriends.Count);
        PumpedFriends.ForEach(x =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
    }
}