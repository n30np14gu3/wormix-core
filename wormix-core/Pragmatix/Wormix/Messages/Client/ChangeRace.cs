namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct ChangeRace(int raceId = 0, int moneyType = 0)
{
    public const int RealMoney = 0;
    public const int Money = 1;

    public int RaceId = raceId;
    public int MoneyType = moneyType;
}
