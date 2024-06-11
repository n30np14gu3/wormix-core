namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct DistributePointsResult
{
    public const int Success = 0;
    public const int Error = 1;
    public const int NotEnoughPoints = 2;
    
    public int Result;
    
}