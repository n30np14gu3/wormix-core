using System.Net;
using System.Net.Sockets;

namespace wormix_core.Server;

public class ClanServer(IPAddress ip, int port) : ServerBehavior(ip, port)
{
    protected override void OnConnect(TcpClient newClient)
    {
        Console.WriteLine("Clan server not implemented");
        newClient?.Client.Close();
    }

    protected override void Process(TcpClient client)
    {
        
    }

    protected override void OnClose(TcpClient client)
    {
        
    }
}