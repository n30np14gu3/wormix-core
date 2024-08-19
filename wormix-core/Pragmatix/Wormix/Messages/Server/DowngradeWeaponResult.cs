using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct DowngradeWeaponResult : ISerializable
{
    public const int Success = 0;

    public short RecipeId;
    public short Result;
    
    public uint GetSize()
    {
        return 4;
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)RecipeId);
        bw.WriteUInt16Be((ushort)Result);
    }
}