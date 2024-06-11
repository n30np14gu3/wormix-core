namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct PumpReactionTheHouseResult
{
    public const int Ok = 0;
    public const int TodayAlreadyPumped = 1;
    public const int Error = 2;
    public const int DayLimitPump = 3;

    public int Result;

}