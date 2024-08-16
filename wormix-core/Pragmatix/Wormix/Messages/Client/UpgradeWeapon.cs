using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct UpgradeWeapon(short recipeId = 0) : ISerializable
{
    public short RecipeId = recipeId;
    public uint GetSize()
    {
        return 2;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}