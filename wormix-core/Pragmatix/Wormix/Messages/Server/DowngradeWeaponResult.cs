namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct DowngradeWeaponResult
{
    public const int Success = 0;

    public int RecipeId;
    public int Result;
}