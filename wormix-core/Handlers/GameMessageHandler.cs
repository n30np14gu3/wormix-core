using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Handlers;

public class GameMessageHandler(ICommandSerializer requestSerializer, GameController controller, TcpSession session)
{
    protected readonly TcpSession Client = session;
    protected readonly GameController MessageController = controller;

    protected ISerializable? requestMessage { get; private set; }
    
    public void Handle(byte[] payload, ICommandHeader header)
    {
        using (MemoryStream ms = new MemoryStream(payload))
        {
            requestMessage = requestSerializer.DeserializeCommand(ms, header);
        }
        Process();
    }

    protected virtual void Process()
    {
        
    }

}