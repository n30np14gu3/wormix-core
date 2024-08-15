using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Service;

public class PingHandler(ICommandSerializer requestSerializer, GameController controller, TcpSession session) : 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        //Sending PONG
        new PongBinarySerializer()
            .SerializeCommand(
                MessageController.ProcessMessage(requestMessage!, Client), 
                Client.GetStream());
    }
}