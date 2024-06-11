using System.Net.Sockets;

namespace wormix_core.Controllers;

public abstract class GameControllerBehavior()
{
    protected byte[]? DataPayload;
    protected TcpClient? Client;

    public void Handle(byte[] payload, TcpClient client)
    {
        DataPayload = payload;
        Client = client;
        Process();
    }

    protected abstract void Process();
    
    public abstract string GetControllerName();
}