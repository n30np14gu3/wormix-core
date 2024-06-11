using System.Net;
using System.Net.Sockets;
using wormix_core.Server;

namespace wormix_core;

abstract class Program
{
    static void Main(string[] argv)
    {
        DomainPolicyServer dpc = new DomainPolicyServer(IPAddress.Parse("127.0.0.1"), 843);
        MainServer ms = new MainServer(IPAddress.Parse("127.0.0.1"), 49197);
        dpc.Start();
        ms.Start();
        Console.ReadLine();
    }
    
}