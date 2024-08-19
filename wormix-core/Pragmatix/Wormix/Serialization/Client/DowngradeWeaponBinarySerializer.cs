using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class DowngradeWeaponBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 88;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        DowngradeWeapon result = new();
        BinaryReader br = new BinaryReader(input);
        result.RecipeId = (short)br.ReadUInt16Be();
        return result;
    }
}