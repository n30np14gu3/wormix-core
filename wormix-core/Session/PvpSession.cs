using wormix_core.Handlers;
using wormix_core.Server;

namespace wormix_core.Session;

public class PvpSession(TcpServer server) : TcpSession(server)
{
    
    protected override void OnConnected()
    {
        Console.WriteLine($"[{Id}] {sessionClient} Connected");
    }

    protected override void OnDisconnected()
    {
        Console.WriteLine($"[{Id}] {sessionClient} Disconnected");
    }

    protected override Dictionary<uint, GameMessageHandler> GetHandlers()
    {
        return new();
    }

    protected override void OnMessage(Stream dataStream)
    {
        ProcessMessage(dataStream);
    }
}