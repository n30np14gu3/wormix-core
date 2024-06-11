namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ShopResult()
{
    public const int Success = 0;
    public const int Error = 1;
    public const int MinRequirementsError = 2;
    public const int NotEnoughMoney = 3;
    public const int ConfirmFailure = 4;

    public int Result;
    public List<object> Weapons = new();
    public List<object> Stuff = new();
}