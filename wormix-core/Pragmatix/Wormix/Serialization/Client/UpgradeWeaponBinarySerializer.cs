using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class UpgradeWeaponBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 86;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        UpgradeWeapon upgradeWeapon = new();
        
        BinaryReader br = new BinaryReader(input);
        upgradeWeapon.RecipeId = (short)br.ReadUInt16Be();
        
        return upgradeWeapon;
    }
}