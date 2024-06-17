using System.Net.Sockets;

namespace wormix_core.Server.Processors;

public abstract class AbstractClientProcessor
{
    public abstract void Process(TcpClient client);
}