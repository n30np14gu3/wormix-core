using wormix_core.Session;

namespace wormix_core.Server;

public class PvpServer(string address, int port) : TcpServer(address, port)
{
    protected override TcpSession CreateSession()
    {
        return new PvpSession(this);
    }
}