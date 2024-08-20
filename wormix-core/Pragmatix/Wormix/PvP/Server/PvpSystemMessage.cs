namespace wormix_core.Pragmatix.Wormix.PvP.Server;

public struct PvpSystemMessage
{
    public const int Undefined = -1;
    
    public const int DroppedByReconnectionTimeout = 1;
    public const int DroppedByCommandTimeout = 2;
    public const int DroppedByResponseTimeout = 3;
    
    public const int Surrendered = 4;
    
    public const int Cheater = 5;
    
    public const int Disconnected = 6;
    public const int Reconnected = 7;
    
    public const int PlayerLongTimeTurn = 8;

    public int Type;
    
    public uint ProfileId;
}