using System.Net;
using System.Net.Sockets;

namespace wormix_core.Server;

public class PvpServer(IPAddress ip, int port) : ServerBehavior(ip, port)
{
    protected override void OnConnect(TcpClient newClient)
    {
        Console.WriteLine("PvP Not implemented");
        newClient?.Close();
    }

    protected override void OnClose(TcpClient client)
    {
        
    }

    protected override void Process(TcpClient client)
    {
        
    }
}