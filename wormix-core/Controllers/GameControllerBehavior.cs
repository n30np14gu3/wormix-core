using System.Net.Sockets;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;

namespace wormix_core.Controllers;

public abstract class GameControllerBehavior()
{
    protected byte[]? DataPayload;
    protected TcpClient? Client;
    protected ICommandHeader? Header;
    

    public void Handle(byte[] payload, TcpClient client, ICommandHeader header)
    {
        DataPayload = payload;
        Client = client;
        Header = header;
        Process();
    }

    protected abstract void Process();
}