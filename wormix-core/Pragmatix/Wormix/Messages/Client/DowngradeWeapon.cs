namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct DowngradeWeapon(int recipeID)
{
    public int RecipeId = recipeID;
}