using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Session;

namespace wormix_core.Handlers;

public abstract class GameMessageHandler()
{
    protected byte[]? DataPayload;
    protected TcpSession? Client;
    
    protected ICommandHeader? Header;
    
    protected IGameController? MessageController { get; private set; }
    
    public void Handle(byte[] payload, TcpSession client, ICommandHeader header)
    {
        DataPayload = payload;
        Client = client;
        Header = header;
        
        bool controllerRequired = true;
        foreach (var attribute in GetType().GetCustomAttributes(false))
        {
            if (attribute is ControlledBy controlledBy)
            {
                controllerRequired = controlledBy.Required;
                if(controllerRequired)
                    MessageController = (IGameController)Activator.CreateInstance(controlledBy.Controller)!;
            }
        }

        if (MessageController == null && controllerRequired)
            throw new Exception($"Can't find ControlledBy attribute in {this}");
        
        Process();
    }

    protected abstract void Process();

}