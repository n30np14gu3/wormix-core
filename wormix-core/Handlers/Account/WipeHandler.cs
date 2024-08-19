using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class WipeHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) : GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is SendWipeConfirmCode)
        {
            new SendWipeConfirmCodeResponseBinarySerializer()
                .SerializeCommand(MessageController.ProcessMessage(requestMessage, Client), Client.GetStream());
            ((MainServerSession)Client).SetWipeRequest();
        }
        
        if (requestMessage is WipeProfile && ((MainServerSession)Client).WipeRequested())
        {
            new WipeProfileResultBinarySerializer()
                .SerializeCommand(MessageController.ProcessMessage(requestMessage, Client), Client.GetStream());
            
        }
    }
}