namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SelectStuffResult
{
    public const int Success = 0;
    public const int Error = 1;

    public int Result;
    public int StuffId;
    public bool IsSecure;
    
}