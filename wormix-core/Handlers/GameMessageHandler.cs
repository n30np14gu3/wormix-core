using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Session;

namespace wormix_core.Handlers;

public class GameMessageHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session)
{
    protected readonly TcpSession Client = session;
    protected readonly IGameController MessageController = controller;

    protected IMessage? requestMessage { get; private set; }
    
    public void Handle(byte[] payload, ICommandHeader header)
    {
        using (MemoryStream ms = new MemoryStream(payload))
        {
            requestMessage = (IMessage)requestSerializer.DeserializeCommand(ms, header);
        }
        Process();
    }

    protected virtual void Process()
    {
        
    }

}