namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SearchTheHouseResult
{
    public const int Empty = 0;
    public const int RealMoney = 1;
    public const int Money = 2;
    public const int Error = 3;
    public const int NoFiveDay = 4;
    public const int KeyLimitExceed = 5;
    public const int Reagent = 7;

    public int Result;
    public int Value;
    public int AvailableSearchKeys;
    public uint FriendId;
    public bool IsSecure;
}