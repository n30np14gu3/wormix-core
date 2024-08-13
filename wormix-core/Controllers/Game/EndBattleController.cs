using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Session;

namespace wormix_core.Controllers.Game;

public class EndBattleController : IGameController
{
    public IMessage ProcessMessage(IMessage gameMessage, TcpSession? session)
    {
        throw new NotImplementedException();
    }

    public string GetRoute()
    {
        throw new NotImplementedException();
    }
}