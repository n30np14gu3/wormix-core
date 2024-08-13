using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class SelectStuffHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) :
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is SelectStuff selectStuffRequest)
        {
            ISerializable response = MessageController.ProcessMessage(selectStuffRequest, Client);
            if (response is SelectStuffResult result)
                new SelectStuffResultBinarySerializer().SerializeCommand(result, Client.GetStream());
        }
    }
}