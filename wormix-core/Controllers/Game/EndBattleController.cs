using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Session;

namespace wormix_core.Controllers.Game;

public class EndBattleController : IGameController
{
    public ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        HttpProcessor.PostRequest($"{Config.Url}{GetRoute()}", gameSerializable, session);
        return null!;
    }

    public string GetRoute()
    {
        return "game/end_battle";
    }
}