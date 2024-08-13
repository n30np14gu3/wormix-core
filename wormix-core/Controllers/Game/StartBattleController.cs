using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Game;

public class StartBattleController : IGameController
{
    public ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest($"{Config.Url}{GetRoute()}", gameSerializable, session).ToObject<JObject>()!;
        return result["data"]!.ToObject<StartBattleResult>();
    }

    public string GetRoute()
    {
        return "game/start_battle";
    }
}