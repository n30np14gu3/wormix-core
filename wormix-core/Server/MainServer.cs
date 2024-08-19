using System.Net;
using wormix_core.Session;

namespace wormix_core.Server;

public class MainServer(string address, int port) : TcpServer(address, port)
{
    protected override TcpSession CreateSession()
    {
        return new MainServerSession(this);
    }
}