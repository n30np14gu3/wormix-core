using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct DowngradeWeapon(short recipeID) : ISerializable
{
    public short RecipeId = recipeID;
    public uint GetSize()
    {
        return 2;
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}