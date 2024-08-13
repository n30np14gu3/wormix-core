using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Game;

public class StartBattleHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) : 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is StartBattle startBattleRequest)
        {
            IMessage result = MessageController.ProcessMessage(startBattleRequest, Client);
            StartBattleResultBinarySerializer serializer = new StartBattleResultBinarySerializer();
            serializer.SerializeCommand(result, Client.GetStream());
        }
    }
}