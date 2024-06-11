namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SendWipeConfirmCodeResponse
{
    public const int Ok = 0;
    public const int DailyLimitExceeded = 1;
    public const int TodayAlreadyWiped = 2;
    public const int WrongMobileNumber = 3;
    public const int Error = 3;

    public int Result;
}