using wormix_core.Extensions;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct WeaponStructure(uint id = 0, int count = 0) : IMessage
{
    public uint Id = id;
    public int Count = count;


    public uint GetSize()
    {
        return
            4 + //Id
            4; // Count
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Id);
        bw.WriteUInt32Be((uint)Count);
    }
}