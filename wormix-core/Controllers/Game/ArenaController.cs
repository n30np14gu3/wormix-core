using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Game;

public class ArenaController : IGameController
{
    public IMessage ProcessMessage(IMessage gameMessage, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest($"{Config.Url}{GetRoute()}", gameMessage, session).ToObject<JObject>()!;
        switch (result["type"]?.ToString())
        {
            case "ArenaResult":
                return result["data"]!.ToObject<ArenaResult>();
            case "ArenaLocked":
                return result["data"]!.ToObject<ArenaLocked>();
            default:
                return new ArenaLocked
                {
                    Delay = Int32.MaxValue,
                    ErrorCode = 1,
                    MissionId = 0
                };
        }
    }

    public string GetRoute()
    {
        return "game/get_arena";
    }
}