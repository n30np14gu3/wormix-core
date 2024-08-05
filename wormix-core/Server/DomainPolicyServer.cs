using System.Net;
using System.Net.Sockets;
using System.Text;

namespace wormix_core.Server;

public class DomainPolicyServer(IPAddress ip, int port) : ServerBehavior(ip, port)
{
    private const string _defaultPolicy = 
        "<?xml version=\"1.0\"?>\n<cross-domain-policy>\n" +
        "<site-control permitted-cross-domain-policies=\"all\"/>\n" +
        "<allow-http-request-headers-from domain=\"*\" headers=\"*\" secure=\"false\"/>\n" +
        "<allow-access-from domain=\"*\" to-ports=\"*\" secure=\"false\"/>\n</cross-domain-policy>\0";
    protected override void OnConnect(TcpClient newClient)
    {
        Console.WriteLine("Sending policy");
    }

    protected override void OnClose(TcpClient client)
    {
        Console.WriteLine("Closed");
    }

    protected override void Process(TcpClient client)
    {
        if (client?.Client != null)
        {
            byte[] policy = new byte[client.Available];
            client.Client.Receive(policy);
            Console.WriteLine($"Policy request:\n{HexDump.HexDump.Format(policy)}");
            client.Client.Send(Encoding.UTF8.GetBytes(_defaultPolicy));
            Thread.Sleep(1000);
            client.Close(); //Close after sending
        }
    }
}