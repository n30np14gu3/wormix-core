namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct NeedMoneyResult
{
    public const int Success = 0;
    public const int Error = 1;
    public const int NotEnoughMoney = 3;

    public int Value;
    public int Result;
    
}