namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct AddToGroup(uint profileId = 0, int moneyType = 0)
{
    public const int RealMoney = 0;
    public const int Money = 1;

    public uint ProfileId = profileId;
    public int MoneyType = moneyType;
}
