using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Game;

public class ArenaController : IGameController
{
    public ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        JObject result = HttpProcessor.PostRequest($"{Config.Url}{GetRoute()}", gameSerializable, session).ToObject<JObject>()!;
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