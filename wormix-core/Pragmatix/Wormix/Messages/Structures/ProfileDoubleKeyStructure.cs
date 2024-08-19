using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct ProfileDoubleKeyStructure : ISerializable
{
    public uint LongId;
    public string StringId;
    
    public uint GetSize()
    {
        return (uint)(
            4 //LongId
            + 2 + StringId.Length //StringId
            );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(LongId);
        bw.WriteUTF8(StringId);
    }
}