namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct ResetParameters(int moneyType = -1)
{
    public const int RealMoney = 0;
    public const int Money = 1;

    public int MoneyType = moneyType;
}