using System.Text;
using wormix_core.Server;

namespace wormix_core.Session;

public class DomainPolicySession(TcpServer server) : TcpSession(server)
{
    private const string _defaultPolicy = 
        "<?xml version=\"1.0\"?>\n<cross-domain-policy>\n" +
        "<site-control permitted-cross-domain-policies=\"all\"/>\n" +
        "<allow-http-request-headers-from domain=\"*\" headers=\"*\" secure=\"false\"/>\n" +
        "<allow-access-from domain=\"*\" to-ports=\"*\" secure=\"false\"/>\n</cross-domain-policy>\0";

    protected override void OnMessage(Stream dataStream)
    {
        if(sessionClient == null)
            return;
        byte[] policy = new byte[sessionClient.Available];
        sessionClient.Client.Receive(policy);
        SendMessage(Encoding.UTF8.GetBytes(_defaultPolicy));
        Thread.Sleep(1000);
        sessionClient.Close(); //Close after sending
    }
}