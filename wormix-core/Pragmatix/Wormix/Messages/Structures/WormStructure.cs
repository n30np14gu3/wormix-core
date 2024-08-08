using wormix_core.Extensions;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct WormStructure : IMessage
{
    public uint OwnerId;
    public string SocialOwnerId;

    public uint Armor;
    public uint Attack;

    public uint Level;
    public uint Experience;

    public short Hat;
    public uint GetSize()
    {
        return
            (uint)(
                4 //OwnerId

                + 4 //Armor
                + 4 //Attack

                + 4 //Level
                + 4 //Experience
                + 2 //Hat
                + 2 + SocialOwnerId.Length
            );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(OwnerId);
        
        bw.WriteUInt32Be(Armor);
        bw.WriteUInt32Be(Attack);
        
        bw.WriteUInt32Be(Level);
        bw.WriteUInt32Be(Experience);
        
        bw.WriteUInt16Be((ushort)Hat);
        
        bw.WriteUTF8(SocialOwnerId);
    }
}