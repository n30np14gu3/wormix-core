using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class PumpReactionRatesHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) : 
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        
    }
}