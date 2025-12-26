using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.PvP.Client;
using wormix_core.Session;

namespace wormix_core.Handlers.PvP;

public class BattleRequestHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) : 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is BattleRequest)
        {
            Console.WriteLine(JsonConvert.SerializeObject(requestMessage));
        }
    }
}