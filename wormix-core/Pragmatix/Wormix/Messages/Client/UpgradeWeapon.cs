namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct UpgradeWeapon(int recipeId = 0)
{
    public int RecipeId = recipeId;
}