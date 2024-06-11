namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct RemoveFromGroupResult
{
    public const int Success = 0;
    public const int Error = 1;

    public int Result;
}